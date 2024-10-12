using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Csharp
{
    class Universe
    {
        public string Name { get; set; }
        public List<Creature> Individuals { get; set; }

        public Universe(string name, List<Creature> individuals)
        {
            Name = name;
            Individuals = individuals;
        }
    }

    class Creature
    {
        public int Id {get; set;}
        public bool? IsHumanoid { get; set; }
        public string? Planet { get; set; }

        public int? Age { get; set;}
        public List<string>? Traits { get; set;}

        public void DataToCreature(JsonNode data)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var deserializedCreature = JsonSerializer.Deserialize<Creature>(data.ToJsonString(), new JsonSerializerOptions(options));

            if(deserializedCreature != null)
            {
                Id = deserializedCreature.Id;
                IsHumanoid = deserializedCreature.IsHumanoid;
                Planet = deserializedCreature.Planet;
                Age = deserializedCreature.Age;
                Traits = deserializedCreature.Traits;
            }
        }


    }

    class Race
    {   
        public string Name {get;set;}
        public bool IsHumanoid {get; set;}
        public string? Planet {get; set;}
        public int Age {get; set;}
        public List<string>? Traits { get; set; }

        public Race(string name, bool isHumanoid, string planet, int age, List<string> traits)
        {
            Name = name;
            IsHumanoid = isHumanoid;
            Planet = planet;
            Age = age;
            Traits = traits;
        }

    }
}