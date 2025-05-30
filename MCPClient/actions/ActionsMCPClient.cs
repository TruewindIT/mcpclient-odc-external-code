using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MCPClient.interfaces;
using MCPClient.structures;
using ModelContextProtocol.Client;
using System.Threading;
using ModelContextProtocol.Protocol;

namespace MCPClient.actions
{
    public class ActionsMCPClient : InterfaceMCPClient
    {
          public ActionsMCPClient()
        {

        }

        public string CallTool(string ServerUrl, List<ToolArgument> ToolArguments, string ToolName)
        {         
            // Use SSE to connect to a remote MCP Server
            var clientTransport = new SseClientTransport(new SseClientTransportOptions
            {
                Endpoint = new Uri(ServerUrl)
            });

            // Convert ToolArguments list to Dictionary with type conversion
            var toolArgumentsDict = new Dictionary<string, object?>();
            foreach (var arg in ToolArguments)
            {
                object? convertedValue;
                switch (arg.Type?.ToLowerInvariant()) // Use null-conditional operator and handle potential null Type
                {
                    case "boolean":
                    case "bool":
                        if (bool.TryParse(arg.Value, out bool boolValue))
                        {
                            convertedValue = boolValue;
                        }
                        else
                        {
                            // Handle parsing failure - default to string or throw error? Defaulting to string for now.
                            convertedValue = arg.Value;
                            // Consider logging a warning here
                        }
                        break;
                    case "integer":
                    case "int":
                        if (int.TryParse(arg.Value, out int intValue))
                        {
                            convertedValue = intValue;
                        }
                        else
                        {
                            convertedValue = arg.Value; // Default to string on failure
                            // Consider logging a warning
                        }
                        break;
                    case "decimal":
                    case "number": // Allow "number" as an alias
                        // Use CultureInfo.InvariantCulture for consistent decimal parsing
                        if (decimal.TryParse(arg.Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal decimalValue))
                        {
                            convertedValue = decimalValue;
                        }
                        else
                        {
                            convertedValue = arg.Value; // Default to string on failure
                            // Consider logging a warning
                        }
                        break;
                    case "date":
                    case "datetime":
                        // Use CultureInfo.InvariantCulture and adjust styles as needed
                        if (DateTime.TryParse(arg.Value, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTime dateValue))
                        {
                            convertedValue = dateValue;
                        }
                        else
                        {
                            convertedValue = arg.Value; // Default to string on failure
                            // Consider logging a warning
                        }
                        break;
                    case "string":
                    case "text":
                    default: // Default to string if type is null, empty, "string", "text", or unrecognized
                        convertedValue = arg.Value;
                        break;
                }
                toolArgumentsDict[arg.Property] = convertedValue;
            }


            // Execute the asynchronous method synchronously
            var client = Task.Run(() => McpClientFactory.CreateAsync(clientTransport)).Result;
            var toolResult = Task.Run(() => client.CallToolAsync(ToolName,
                                                            toolArgumentsDict,
                                                            null,
                                                            null,
                                                            CancellationToken.None)).Result;

            var callToolResponse = toolResult.Result;

            // Convert the tool result to text
            string textResult = callToolResponse.Content.First(c => c.Type == "text").Text;
            return textResult;
           
        }


        public string GetTools(string ServerUrl)
        {
            // Use SSE to connect to a remote MCP Server
            var clientTransport = new SseClientTransport(new SseClientTransportOptions
            {
                Endpoint = new Uri(ServerUrl)
            });

            // Execute the asynchronous method synchronously
            var client = Task.Run(() => McpClientFactory.CreateAsync(clientTransport)).Result;
            var tools = Task.Run(() => client.ListToolsAsync()).Result;

            var toolsList = tools.Result;

            // Convert the list of tools to JSON
            string jsonTools = JsonSerializer.Serialize(toolsList);
            return jsonTools;
        }

    }
}
