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
            input.SetInputFile("input.json");

            string[] universeName = {"starWars", "hitchHiker", "rings", "marvel"};
            Dictionary<string, Universe> universes = new Dictionary<string, Universe>();
            foreach(string universe in universeName) 
                universes[universe] = new Universe(universe, new List<Creature>());

            var data = input.GetData();

            Dictionary < Universe, Race[] > races = new Dictionary<Universe, Race[]>();
            races[universes["starWars"]] = new Race[] {
                new Race("Wookie", false, "Kashyyyk", 400, new List<string>{"HAIRY", "TALL"}),
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
                new Race("Elf", true, "Earth", int.MaxValue, new List<string>{"BLONDE", "POINTY_EARS"}),
                new Race("Dwarf", true, "Earth", 200, new List<string>{"SHORT", "BULKY"}),
            };


            if (data != null)
            {
                foreach(var entry in data)
                {
                    Creature creature = new Creature();
                    creature.DataToCreature(entry);
                    
                    
                    // Console.WriteLine("Id:{0}  Human:{1}  Age:{2}  Planet:{3}  Traits:{4}", creature.Id, creature.IsHumanoid, creature.Age, creature.Planet, creature.Traits);
                    //Console.WriteLine(entry.ToString());
                    Dictionary<Universe, List<Race>> potentialOutput = new Dictionary<Universe, List<Race>>();

                    foreach(var raceKeyValuePair in races)
                    {
                        Universe currentUniverse = raceKeyValuePair.Key;
                        Race[] currentRaces = raceKeyValuePair.Value;
                     

                        foreach(var race in currentRaces)
                        {
                            // Console.WriteLine("{0}:{1}",creature.Id,creature.IsHumanoid);
                            if (creature.IsHumanoid != null && (creature.IsHumanoid != race.IsHumanoid)) continue;
                            else if (creature.Planet != null && (creature.Planet != race.Planet)) continue;
                            else if (creature.Age != 0 && (creature.Age > race.Age)) continue;
                            //else if (creature.Traits != null && race.Traits != null && !creature.Traits.Intersect(race.Traits).Any()) continue;
                            else if (creature.Traits != null && creature.Traits.Any())
                            {
                                // If the race has no traits or any of the creature's traits are not in the race, skip it
                                if (race.Traits == null || creature.Traits.Any(trait => !race.Traits.Contains(trait)))
                                {
                                    continue;
                                }
                            }


                            // Check if the universe already exists in potentialOutput
                            if (!potentialOutput.ContainsKey(currentUniverse))
                            {
                                // If it doesn't exist, add a new entry with a list containing the current race
                                potentialOutput[currentUniverse] = new List<Race> { race };
                            }
                            else
                            {
                                // If it exists, add the race to the existing list
                                potentialOutput[currentUniverse].Add(race);
                               
                            }
                        }

                    }

                    if(potentialOutput.Keys.Count == 1)
                    {
                        var universeKeyValuePair = potentialOutput.First();
                        Universe matchedUniverse = universeKeyValuePair.Key;
                        List<Race> matchedRaces = universeKeyValuePair.Value;

                        // Add the creature to the Individuals list of the matched universe
                        if (matchedRaces.Count == 1)
                        {
                            matchedUniverse.Individuals.Add(creature);
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

