using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Csharp
{
    // We use this class to attribute the data of each entry/JsonObject from data list of the input file to separate objects
    class Creature
    {
        // Fields that are populated by data after deserialization
        public int Id {get; set;}
        public bool? IsHumanoid { get; set; }
        public string? Planet { get; set; }

        public int? Age { get; set;}
        public List<string>? Traits { get; set;}

        // Method that called will deserialize the data of each data/JsonArray entry into the proper fields of a Creature object
        public void DataToCreature(JsonNode data)
        {
            // Options for deserialization
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // The actual deserialization process
            var deserializedCreature = JsonSerializer.Deserialize<Creature>(data.ToJsonString(), new JsonSerializerOptions(options));

            // Attributing each deserialized field to the proper Creature field
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
}