using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Csharp
{
    class Universe
    {
        public string Name { get; set; } // Name of the Universe

        // This following list gets populated by the Creatures that were sorted to the right Universe they belong to
        public List<Creature> Individuals { get; set; } 

        public Universe(string name, List<Creature> individuals)
        {
            Name = name;
            Individuals = individuals;
        }
    }
}