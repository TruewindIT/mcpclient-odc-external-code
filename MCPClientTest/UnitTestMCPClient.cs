using MCPClient.actions;
using MCPClient.structures;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;
using static System.Net.WebRequestMethods;
//using MCPClient.structures;

namespace MCPClientTest {
    public class UnitTestMCPClientTest {
        ActionsMCPClient _actionsMCPClient;
        private readonly ITestOutputHelper _output;
        
        String mcpServerURL = "https://mcp.pipedream.net/<api-key>/polygon";

        public UnitTestMCPClientTest(ITestOutputHelper output)
        {
            _actionsMCPClient = new ActionsMCPClient();
            _output = output;
        }


        [Fact]
        public void CallTool() {
            List<ToolArgument> arguments = new List<ToolArgument>();
            ToolArgument argument = new ToolArgument();
            argument.Property = "instruction";
            argument.Value = "AAPL 2025-05-28";
            argument.Type = "String";
            arguments.Add(argument);

            String result = _actionsMCPClient.CallTool(mcpServerURL, arguments, "POLYGON-GET-STOCK-PRICE");

            _output.WriteLine("### CallTool result ### : " + result);

            //String expectedValue = "";
            //String actualValue = result;

            //Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GetTools() {
            String result = _actionsMCPClient.GetTools(mcpServerURL);

            _output.WriteLine("### GetTools result ### : " + result);

            //String expectedValue = "";
            //String actualValue = result;

            //Assert.Equal(expectedValue, actualValue);
        }

    }
}