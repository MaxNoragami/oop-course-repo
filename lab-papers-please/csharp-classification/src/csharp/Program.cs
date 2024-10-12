using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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
            foreach(string universe in universeName) 
                universes[universe] = new Universe(universe, new List<Creature>());

            var data = input.GetData();

            Dictionary < Universe, Race[] > races =  new Dictionary<Universe, Race[]>();
            races[universes["starWars"]] = new Race[] {
                new Race("Wookie", false, "Kashyyk", 400, new List<string>{"HAIRY", "TALL"}),
                new Race("Ewok", false, "Endor", 60, new List<string>{"SHORT", "HAIRY"}),
            };
            races[universes["marvel"]] = new Race[] {
                new Race("Asgardian", true, "Asgard", 5000, new List<string>{"BLONDE", "TALL"}),
            };
            races[universes["hitchHiker"]] = new Race[] {
                new Race("Betelgeusian", true, "Betelgeuse", 100, new List<string>{"EXTRA_ARMS", "EXTRA_HEAD"}),
                new Race("Vogons", false, "Vogsphere", 200, new List<string>{"GREEN", "BULKY"}),
            };
            races[universes["rings"]] = new Race[] {
                new Race("Elf", true, "Earth", -1, new List<string>{"BLONDE", "POINTY_EARS"}),
                new Race("Dwarf", true, "Earth", 200, new List<string>{"SHORT", "BULKY"}),
            };


            if (data != null)
            {
                foreach(var entry in data)
                {
                    Creature creature = new Creature();
                    creature.DataToCreature(entry);
                    Console.WriteLine("Id:{0}  Human:{1}  Age:{2}  Planet:{3}  Traits:{4}", creature.Id, creature.IsHumanoid, creature.Age, creature.Planet, creature.Traits);
                    
                    Console.WriteLine(entry.ToString());
                    string? userInput = Console.ReadLine();
                    switch(userInput.Trim())
                    {
                        case "1":
                        {
                            universes["starWars"].Individuals.Add(creature);
                            break;
                        }
                        case "2":
                        {
                            universes["hitchHiker"].Individuals.Add(creature);
                            break;
                        }
                        case "3":
                        {
                            universes["rings"].Individuals.Add(creature);
                            break;
                        }
                        case "4":
                        {
                            universes["marvel"].Individuals.Add(creature);
                            break;
                        }
                    }
                }
            }

            var options = new JsonSerializerOptions
            {
                
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            };

            string outputDirectory = Path.Combine(input.BaseDir, "..", "..", "..", "..", "resources", "output");
          
            File.WriteAllText(Path.Combine(outputDirectory, "starwars.json"), JsonSerializer.Serialize(universes["starWars"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "hitchhiker.json"), JsonSerializer.Serialize(universes["hitchHiker"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "rings.json"), JsonSerializer.Serialize(universes["rings"], options));
            File.WriteAllText(Path.Combine(outputDirectory, "marvel.json"), JsonSerializer.Serialize(universes["marvel"], options));

        }
    }

}

