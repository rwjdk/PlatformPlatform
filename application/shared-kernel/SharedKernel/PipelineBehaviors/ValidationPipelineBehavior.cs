using System.Net;
using FluentValidation;
using PlatformPlatform.SharedKernel.Cqrs;
using PlatformPlatform.SharedKernel.Validation;

namespace PlatformPlatform.SharedKernel.PipelineBehaviors;

/// <summary>
///     The ValidationPipelineBehavior class is a MediatR pipeline behavior that validates the request using
///     FluentValidation. If the request is not valid, the pipeline will be short-circuited and the request will not be
///     handled. If the request is valid, the next pipeline behavior will be called.
/// </summary>
public sealed class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TResponse : ResultBase where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            // Run all validators in parallel and await the results
            var validationResults =
                await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            // Aggregate the results from all validators into a distinct list of errorDetails
            var errorDetails = validationResults
                .SelectMany(result => result.Errors)
                .Where(failure => failure is not null)
                .Select(failure => new ErrorDetail(failure.PropertyName, failure.ErrorMessage))
                .Distinct()
                .ToArray();

            if (errorDetails.Length > 0)
            {
                return CreateValidationResult<TResponse>(errorDetails);
            }
        }

        return await next(cancellationToken);
    }

    /// <summary>
    ///     Uses reflection to create a new instance of the specified Result type, passing the errorDetails to the
    ///     constructor.
    /// </summary>
    private static TResult CreateValidationResult<TResult>(ErrorDetail[] errorDetails)
        where TResult : ResultBase
    {
        return (TResult)Activator.CreateInstance(typeof(TResult), HttpStatusCode.BadRequest, null, false, errorDetails)!;
    }
}
