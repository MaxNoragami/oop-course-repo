using System;
using System.Text.Json.Nodes;

namespace Csharp
{
    // Class that defines the logic of the repartion of each Creature to the Universe it belongs to
    class Repartition
    {
        // Main function that gets called for sorting the creatures into the right universes
        public void ToUniverse(JsonArray? data, Dictionary<Universe, Race[]> races, Dictionary<string, Universe> universes)
        {
            if (data != null)
            {
                // We iterate through each entry of the JsonArray (the data array from the input file)
                foreach (var entry in data)
                {
                    // We initiate a Creature object for each JsonObject from the JsonArray/data
                    Creature creature = new Creature();
                    creature.DataToCreature(entry);

                    // We process the Creature info by sending it to the right Universe
                    ProcessEntry(races, creature, universes);
                }
            }
        }

        // We process the Creature info by sending it to the right Universe
        private void ProcessEntry(Dictionary<Universe, Race[]> races, Creature creature, Dictionary<string, Universe> universes)
        {
            // We start iterating through each available race of each universe and checking if the creature belongs to it
            foreach (var raceKeyValuePair in races)
            {
                // We get become awere of which universe and race we are working with
                Universe currentUniverse = raceKeyValuePair.Key;
                Race[] currentRaces = raceKeyValuePair.Value;

                // We start iterating through each race of the current Universe we are on
                foreach (var race in currentRaces)
                {
                    // We check if the creature matches the race and if 'true' we attribute it to its Universe
                    if (IsRaceMatchCreature(creature, race))
                    {
                        universes[currentUniverse.Name].Individuals.Add(creature);
                    }
                }
            }
        }

        // Function to check if the current creature we are dealing with belongs to the current Race
        private bool IsRaceMatchCreature(Creature creature, Race race)
        {
            // If the creature doesnt match one of the race fields it will be checked against the following race
            if (creature.IsHumanoid != null && creature.IsHumanoid != race.IsHumanoid) return false;
            if (creature.Planet != null && creature.Planet != race.Planet) return false;
            if (creature.Age != null && creature.Age > race.Age) return false;
            if (creature.Traits != null && creature.Traits.Any() && (race.Traits == null || creature.Traits.Any(trait => !race.Traits.Contains(trait)))) return false;

            // If the creature matches the current race
            return true;
        }
    }
}