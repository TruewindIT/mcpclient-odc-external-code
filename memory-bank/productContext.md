# Product Context: MCPClient Library

**Problem:** OutSystems applications need a standardized way to interact with external systems and tools exposed via the Model Context Protocol (MCP), specifically connecting to remote servers. There's also a need to integrate these MCP tools seamlessly with the OutSystems AI Agent Builder.

**Solution:** The `MCPClient` External Library provides a bridge between OutSystems and MCP remote servers. It abstracts the complexities of the MCP protocol and communication with remote servers, offering simple OutSystems actions.

**Goals:**
*   Enable OutSystems developers to easily consume MCP tools without deep knowledge of the underlying protocol.
*   Support dynamic discovery and invocation of MCP tools.
*   Ensure correct data type handling for tool arguments.
*   Provide specific actions tailored for integration with AI Agent Builder.
*   Offer a reliable and well-documented component for OutSystems applications.
