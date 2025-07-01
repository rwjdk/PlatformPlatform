using System.CommandLine;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using PlatformPlatform.DeveloperCli.Commands;
using PlatformPlatform.DeveloperCli.Installation;
using Spectre.Console;

var isDebugBuild = new FileInfo(Environment.ProcessPath!).FullName.Contains("debug");
ChangeDetection.EnsureCliIsCompiledWithLatestChanges(isDebugBuild);

if (!Configuration.IsMacOs && !Configuration.IsWindows && !Configuration.IsLinux)
{
    AnsiConsole.MarkupLine($"[red]Your OS [bold]{Environment.OSVersion.Platform}[/] is not supported.[/]");
    Environment.Exit(1);
}

if (args.Length == 0)
{
    args = ["--help"];
}

if (args[0] == "mcp")
{
    var builder = Host.CreateApplicationBuilder();

    builder.Services
        .AddMcpServer()
        .WithStdioServerTransport()
        .WithTools([
                McpServerTool.Create(Hello, new McpServerToolCreateOptions
                    {
                        Name = "Rebuild-Backend",
                        Description = "Rebuild the backend of PlatformPlatform"
                    }
                )
            ]
        );

    builder.Build().Run();
}

var solutionName = new DirectoryInfo(Configuration.SourceCodeFolder).Name;
if (args.Length == 1 && (args[0] == "--help" || args[0] == "-h" || args[0] == "-?"))
{
    var figletText = new FigletText(solutionName);
    AnsiConsole.Write(figletText);
}

AnsiConsole.WriteLine($"Source code folder: {Configuration.SourceCodeFolder} \n");

var rootCommand = new RootCommand
{
    Description = $"Welcome to the {solutionName} Developer CLI!"
};

var allCommands = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => !t.IsAbstract && t.IsAssignableTo(typeof(Command)))
    .Select(Activator.CreateInstance)
    .Cast<Command>()
    .ToList();

if (!isDebugBuild)
{
    // Remove InstallCommand if isDebugBuild is false
    allCommands.Remove(allCommands.First(c => c.Name == "install"));
}

allCommands.ForEach(rootCommand.AddCommand);

await rootCommand.InvokeAsync(args);

static string Hello(bool backend, bool frontend)
{
    BuildCommand.Execute(backend, frontend, null);
    return "Backend Built";
}
