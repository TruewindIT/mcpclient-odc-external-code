using OutSystems.ExternalLibraries.SDK;
using MCPClient.structures;

namespace MCPClient.interfaces
{
    [OSInterface(
        Name = "MCPClient",
        Description = "Provides actions to interact with Model Context Protocol (MCP) remote servers. Allows OutSystems applications to call tools and retrieve information from connected MCP server endpoints.",
        IconResourceName = "MCPClient.182288589.png"
    )]
    public interface InterfaceMCPClient
    {
        [OSAction(
            Description = "Calls a specific tool exposed by a connected MCP server.",
            ReturnDescription = "The primary text content returned by the executed MCP tool.",
            ReturnName = "ToolResponse",
            ReturnType = OSDataType.Text
        )]
        string CallTool(
            [OSParameter(Description = "The endpoint URL of the target MCP server (e.g., 'http://localhost:8888/sse').")] string ServerUrl,
            [OSParameter(Description = "A list of arguments required by the tool. See the ToolArgument structure definition.")] List<ToolArgument> ToolArguments,
            [OSParameter(Description = "The name of the tool to execute on the MCP server.")] string ToolName);

        [OSAction(
            Description = "Retrieves a list of available tools from a connected MCP server.",
            ReturnDescription = "A JSON string representing the list of tools available on the server, including their names, descriptions, and input schemas.",
            ReturnName = "Tools",
            ReturnType = OSDataType.Text
        )]
        string GetTools(
            [OSParameter(Description = "The endpoint URL of the target MCP server (e.g., 'http://localhost:8888/sse').")] string ServerUrl);
    }
}
