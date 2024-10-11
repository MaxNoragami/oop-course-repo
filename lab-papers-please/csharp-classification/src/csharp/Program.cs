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

            string[] universeName = {"starWars", "hitchHiker", "rings", "marvel"};
            Dictionary<string, Universe> universes = new Dictionary<string, Universe>();
            foreach(string universe in universeName) universes[universe] = new Universe(universe, new List<JsonNode>());


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
                            universes["starWars"].Individuals.Add(entry);
                            break;
                        }
                        case "2":
                        {
                            universes["hitchHiker"].Individuals.Add(entry);
                            break;
                        }
                        case "3":
                        {
                            universes["rings"].Individuals.Add(entry);
                            break;
                        }
                        case "4":
                        {
                            universes["marvel"].Individuals.Add(entry);
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
          
            File.WriteAllText(Path.Combine(outputDirectory, "starwars.json"), JsonSerializer.Serialize(universes["starWars"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "hitchhiker.json"), JsonSerializer.Serialize(universes["hitchHiker"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "rings.json"), JsonSerializer.Serialize(universes["rings"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "marvel.json"), JsonSerializer.Serialize(universes["marvel"], options));

        }
    }

}

