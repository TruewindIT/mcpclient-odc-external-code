using OutSystems.ExternalLibraries.SDK;

namespace MCPClient.structures
{
    [OSStructure(
        Description = "Represents a single argument to be passed when calling an MCP tool."
    )]
    public struct ToolArgument
    {
        [OSStructureField(
            DataType = OSDataType.Text,
            Description = "The name of the tool argument/parameter.",
            IsMandatory = true,
            Length = 0 // Length 0 often means unspecified/unlimited in OS context for Text
        )]
        public string Property;
        [OSStructureField(
            DataType = OSDataType.Text,
            Description = "The value of the tool argument, provided as text. It will be converted to the specified 'Type' before calling the tool.",
            IsMandatory = true,
            Length = 0 // Assuming value can be long
        )]
        public string Value;

        [OSStructureField(
            DataType = OSDataType.Text,
            Description = "The intended data type of the Value (e.g., 'string', 'integer', 'boolean', 'decimal', 'date').",
            IsMandatory = true,
            Length = 50 // Assuming a reasonable max length for type names
        )]
        public string Type;
    }
}
