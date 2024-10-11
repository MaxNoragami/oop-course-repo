using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Csharp
{
    class Program
    {
        static void Main()
        {
            var input = new Input();
            input.SetInputFile("test-input.json");

            var starWars = new Universe("starWars", new List<JsonNode>());
            var hitchHiker = new Universe("hitchHiker", new List<JsonNode>());
            var rings = new Universe("rings", new List<JsonNode>());
            var marvel = new Universe("marvel", new List<JsonNode>());

            var data = input.GetData();

            if(data != null)
            {
                foreach(var entry in data)
                {
                    Console.WriteLine(entry.ToString());
                    string? userInput = Console.ReadLine();
                    switch(userInput.Trim())
                    {
                        case "1":
                        {
                            starWars.Individuals.Add(entry);
                            break;
                        }
                        case "2":
                        {
                            hitchHiker.Individuals.Add(entry);
                            break;
                        }
                        case "3":
                        {
                            rings.Individuals.Add(entry);
                            break;
                        }
                        case "4":
                        {
                            marvel.Individuals.Add(entry);
                            break;
                        }
                    }
                }
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string outputDirectory = Path.Combine(input.BaseDir, "..", "..", "..", "..", "resources", "output");
          
            File.WriteAllText(Path.Combine(outputDirectory, "starwars.json"), JsonSerializer.Serialize(starWars, options));
            File.WriteAllText(Path.Combine(outputDirectory, "hitchhiker.json"), JsonSerializer.Serialize(hitchHiker, options));
            File.WriteAllText(Path.Combine(outputDirectory, "rings.json"), JsonSerializer.Serialize(rings, options));
            File.WriteAllText(Path.Combine(outputDirectory, "marvel.json"), JsonSerializer.Serialize(marvel, options));

        }
    }

}

