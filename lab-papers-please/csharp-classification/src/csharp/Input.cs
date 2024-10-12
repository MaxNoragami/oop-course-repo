using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Csharp
{
    public class Input
    {
        public string FileName {get;set;} // The name of the file we get our input from
        private static string? inputFile;
        private string baseDir = AppContext.BaseDirectory;

        // Method to deserialize the data from the input files
        public JsonArray? GetData()
        {
            inputFile = Path.Combine(baseDir, "..", "..", "..", "..", "resources", "input", FileName); // Path of the input file
            if(File.Exists(inputFile))
            {
                string? jsonData = File.ReadAllText(inputFile);
                JsonArray? data = JsonNode.Parse(jsonData)?["data"]?.AsArray(); // We save the JSON objects into a JsonArray
                return data;
            }
            return null;
        }

        // Constructor for setting the name of the File
        public Input(string fileName)
        {
            FileName = fileName;
        }       

    }
}