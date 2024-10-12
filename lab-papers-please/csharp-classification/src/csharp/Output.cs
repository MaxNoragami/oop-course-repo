using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Csharp
{
    static class Output
    {
        static private string baseDir = AppContext.BaseDirectory;

        
        static public void SetData(string[] universeName, Dictionary<string, Universe> universes)
        {
            var options = new JsonSerializerOptions {
                WriteIndented = true, 
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            

            string outputDirectory = Path.Combine(baseDir, "..", "..", "..", "..", "resources", "output");

            foreach(var universe in universeName)
                File.WriteAllText(Path.Combine(outputDirectory, universe + ".json"), JsonSerializer.Serialize(universes[universe], options));
            
        }
        
    }
}