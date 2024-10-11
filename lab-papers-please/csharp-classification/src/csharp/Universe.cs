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
}