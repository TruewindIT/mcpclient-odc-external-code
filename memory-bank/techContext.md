# Technical Context: MCPClient Library

**Core Technologies:**
*   **.NET 8:** The target framework for the class library.
*   **C#:** The programming language used.

**Key Dependencies:**
*   **`OutSystems.ExternalLibraries.SDK` (v1.4.0):** Provides the necessary attributes (`[OSInterface]`, `[OSAction]`, etc.) and base types for creating OutSystems External Libraries.
*   **`ModelContextProtocol` (v0.1.0-preview.8):** The client library used for handling MCP communication, specifically the `SseClientTransport` for Server-Sent Events.

**Development Environment:**
*   Assumed to be Visual Studio or VS Code with .NET SDK installed.
*   PowerShell is used for the build/packaging script (`CompileAndGenerateRelease.ps1`).

**Deployment:**
*   The library is packaged into a ZIP file using the PowerShell script.
*   This ZIP file is intended for upload into an OutSystems environment (ODC or O11).

**Tooling:**
*   `.NET CLI`: Used for building (`dotnet publish`).
*   `PowerShell`: Used for scripting the build and packaging process.
*   `OutSystems Service Studio / ODC Portal`: Used for uploading and consuming the final library package.
