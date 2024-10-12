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
            // Options for serializing
            var options = new JsonSerializerOptions {
                WriteIndented = true, // For better vizualization of saved data
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Following the right name cases
            };

            // Path of the foleder where the output files will be saved to
            string outputDirectory = Path.Combine(baseDir, "..", "..", "..", "..", "resources", "output"); 

            // Dynamically serializing the data of each universe into the right json file
            foreach(var universe in universeName)
                File.WriteAllText(Path.Combine(outputDirectory, universe + ".json"), JsonSerializer.Serialize(universes[universe], options));
            
        }
        
    }
}