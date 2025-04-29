# MCPClient External Library for OutSystems

Provides actions to interact with Model Context Protocol (MCP) remote servers. Allows OutSystems applications to call tools and retrieve information from connected MCP server endpoints.

## Actions

### CallTool

Calls a specific tool exposed by a connected MCP server.

**Parameters:**

*   `ServerUrl` (Text): The endpoint URL of the target MCP server (e.g., `http://localhost:8888/sse`).
*   `ToolArguments` (List of ToolArgument Structure): A list of arguments required by the tool. See the `ToolArgument` structure definition below.
*   `ToolName` (Text): The name of the tool to execute on the MCP server.

**Returns:**

*   `ToolResponse` (Text): The primary text content returned by the executed MCP tool.

### GetTools

Retrieves a list of available tools from a connected MCP server.

**Parameters:**

*   `ServerUrl` (Text): The endpoint URL of the target MCP server (e.g., `http://localhost:8888/sse`).

**Returns:**

*   `Tools` (Text): A JSON string representing the list of tools available on the server, including their names, descriptions, and input schemas.

## Structures

### ToolArgument

Represents a single argument to be passed when calling an MCP tool.

**Fields:**

*   `Property` (Text, Mandatory): The name of the tool argument/parameter.
*   `Value` (Text, Mandatory): The value of the tool argument, provided as text. It will be converted to the specified 'Type' before calling the tool.
*   `Type` (Text, Mandatory): The intended data type of the Value (e.g., 'string', 'integer', 'boolean', 'decimal', 'date').

## Building and Packaging

To package this library for use in OutSystems:

1.  Ensure you have the .NET SDK installed.
2.  Run the `CompileAndGenerateRelease.ps1` PowerShell script located in the `MCPClient` directory.
    ```powershell
    .\CompileAndGenerateRelease.ps1
    ```
3.  This script will build the project and create a `MCPClient.zip` file inside a `dist` sub-directory.
4.  Upload this `MCPClient.zip` file to your OutSystems environment (ODC Portal or Service Studio).
