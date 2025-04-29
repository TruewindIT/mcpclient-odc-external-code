# Active Context: MCPClient Library (2025-04-28)

**Current Focus:** Documentation and finalization of the core `MCPClient` external library and its associated OutSystems wrapper library ("MCP Client Library").

**Recent Changes:**
*   Added a `Type` field to the `ToolArgument` structure to support runtime type conversion.
*   Modified the `CallTool` action implementation (`ActionsMCPClient.cs`) to parse the `Value` field based on the `Type` field (handling boolean, integer, decimal, date/datetime).
*   Added comprehensive documentation to the C# code using OutSystems SDK attributes (`[OSInterface]`, `[OSAction]`, `[OSParameter]`, `[OSStructure]`, `[OSStructureField]`).
*   Updated documentation to refer to communication with remote MCP servers.
*   Created a `README.md` file summarizing the library's functionality and build process.
*   Embedded an icon (`182288589.png`) into the project for use in OutSystems.
*   Drafted descriptions for a conceptual OutSystems wrapper library ("MCP Client Library") and its actions (`CallMCPTool`, `CallMCPTool_AgentBuilder`, `GetMCPTools`, `MCPTools_FormatToAgentBuilder`), including specific considerations for AI Agent Builder integration.

**Next Steps:**
*   Review and potentially implement the actions described for the "MCP Client Library" wrapper module within the OutSystems platform itself (this is outside the scope of the C# external library code).
*   Verify the build and packaging process using `CompileAndGenerateRelease.ps1`.
*   Test the deployed library within an OutSystems application, including the AI Agent Builder integration points if implemented.

**Key Patterns/Preferences:**
*   Documentation should be embedded within the C# code using SDK attributes for optimal OutSystems integration.
*   The library facilitates MCP communication with remote servers.
*   Argument type handling is crucial for robust tool calls.
*   Clear distinction between the core external library (.NET code) and any OutSystems wrapper library.
