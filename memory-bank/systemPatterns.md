# System Patterns: MCPClient Library

**Architecture:**
*   The project is a .NET 8 Class Library designed as an OutSystems External Library.
*   It utilizes the `OutSystems.ExternalLibraries.SDK` for defining the interface, actions, parameters, and structures visible within the OutSystems platform.
*   It leverages the `ModelContextProtocol` client library to handle communication with MCP servers.

**Key Technical Decisions & Patterns:**
*   **MCP Communication:** Uses the Server-Sent Events (SSE) protocol via `SseClientTransport` from the `ModelContextProtocol` library for efficient, server-pushed communication.
*   **Interface Definition:** The `InterfaceMCPClient.cs` file defines the contract exposed to OutSystems, using attributes like `[OSInterface]`, `[OSAction]`, and `[OSParameter]` for discoverability and documentation within the OutSystems IDE.
*   **Implementation Separation:** The `ActionsMCPClient.cs` class implements the defined interface, encapsulating the logic for connecting to the MCP server, calling tools, and handling results.
*   **Custom Structures:** The `StructuresMCPClient.cs` file defines custom data structures (e.g., `ToolArgument`) needed for action parameters, using `[OSStructure]` and `[OSStructureField]` attributes.
*   **Argument Type Handling:** The `CallTool` implementation includes logic to parse string-based `Value` inputs from OutSystems into appropriate .NET types (`bool`, `int`, `decimal`, `DateTime`) based on a provided `Type` string, before sending the arguments to the MCP tool. This ensures data integrity.
*   **Asynchronous Operations:** Although the OutSystems actions are synchronous, the underlying MCP client calls (`CallToolAsync`, `ListToolsAsync`) are asynchronous. The implementation uses `Task.Run(...).Result` to bridge this gap, effectively running the async calls synchronously within the context of the OutSystems action.
*   **Packaging:** A PowerShell script (`CompileAndGenerateRelease.ps1`) automates the build (`dotnet publish`) and packaging (`Compress-Archive`) process, creating a deployable ZIP archive for OutSystems.
*   **Icon:** The library icon is provided by embedding an image file (`182288589.png`) directly into the assembly via the `.csproj` file.
*   **AI Agent Builder Integration:** Specific actions (`CallMCPTool_AgentBuilder`, `MCPTools_FormatToAgentBuilder`) are intended (though potentially not fully implemented in the reviewed code) to provide formatted data suitable for direct use with OutSystems AI Agent Builder.
