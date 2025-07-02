using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using PlatformPlatform.DeveloperCli.Installation;
using PlatformPlatform.DeveloperCli.Utilities;

namespace PlatformPlatform.DeveloperCli.Commands;

public class McpCommand : Command
{
    public McpCommand() : base("mcp", "Start as MCP")
    {
        Handler = CommandHandler.Create(Execute);
    }

    private static void Execute()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services
            .AddMcpServer()
            .WithStdioServerTransport()
            .WithTools([
                    McpServerTool.Create(Hello, new McpServerToolCreateOptions
                        {
                            Name = "Hello"
                        }
                    )
                ]
            );

        builder.Build().Run();
    }

    public static string Hello()
    {
        return "M42";
    }
}
