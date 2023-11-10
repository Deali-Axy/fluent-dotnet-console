using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using FluentConsole.Template.Entities;

namespace FluentConsole.Template.MISC;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(OutputResult))]
internal partial class SourceGenerationContext : JsonSerializerContext {
    
}