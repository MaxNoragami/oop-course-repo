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

            // NON-CLASSABLE
            string[] universeName = {"starWars", "hitchHiker", "rings", "marvel"};
            Dictionary<string, Universe> universes = new Dictionary<string, Universe>();
            foreach(string universe in universeName) 
                universes[universe] = new Universe(universe, new List<Creature>());

            var data = input.GetData();


            // NON-CLASSABLE
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

            // CLASSABLE
            new Repartition().ToUniverse(data, races, universes);
            
            Output.SetData(universeName, universes);

        }
    }

}

