using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Csharp
{
    public class Input
    {
        private static string? fileName;
        private static string? inputFile;

        public string BaseDir {get; set;}

         public void SetInputFile(string file)
         {
            fileName = file;
         }

         public JsonArray GetData()
         {
            inputFile = Path.Combine(BaseDir, "..", "..", "..", "..", "resources", "input", fileName);
            string? jsonData = File.ReadAllText(inputFile);
            JsonArray? data = JsonNode.Parse(jsonData)?["data"]?.AsArray();
            return data;
        }

        public Input()
        {
            BaseDir = AppContext.BaseDirectory;
        }       

    }
}