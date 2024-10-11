using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Csharp
{
    class Universe
    {
        public string Name { get; set; }
        public List<JsonNode> Individuals { get; set; }

        public Universe(string name, List<JsonNode> individuals)
        {
            Name = name;
            Individuals = individuals;
        }
    }

    class Creature
    {
        public int Id {get; set;}
        public bool IsHumanoid { get; set; }
        public string? Planet { get; set; }

        public int Age { get; set;}
        public List<string>? Traits { get; set;}


    }
}