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
            // Here we initiate the 'Input' class setting up the name of the source file that has the input
            var input = new Input("input.json");

            // We define the available universes in an array and we generate Universe objects for each of them
            string[] universeName = {"starWars", "hitchHiker", "rings", "marvel"};
            Dictionary<string, Universe> universes = new Dictionary<string, Universe>();
            foreach(string universe in universeName) 
                universes[universe] = new Universe(universe, new List<Creature>());

            // Call the method in order to get the data that was deserialized from the input
            var data = input.GetData();

            // We set up a dictionary where we have as keys the Universes and as values an array of available Races in that universe
            Dictionary < Universe, Race[] > races = new Dictionary<Universe, Race[]>();

            // We initate the races that are available in each Universe
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

            // We attribute each lost creature in the right universe it belongs to
            new Repartition().ToUniverse(data, races, universes);
            
            // Serialize the results to the output files
            Output.SetData(universeName, universes);

        }
    }

}

