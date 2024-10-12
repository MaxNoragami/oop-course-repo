using System;
using System.Text.Json.Nodes;

namespace Csharp
{
    class Repartition
    {
        
        public void ToUniverse(JsonArray? data, Dictionary<Universe, Race[]> races)
        {
            if (data != null)
            {
                foreach (var entry in data)
                {
                    Creature creature = new Creature();
                    creature.DataToCreature(entry);

                    Dictionary<Universe, List<Race>> potentialOutput = new Dictionary<Universe, List<Race>>();

                    MatchCreatureToUniverse(potentialOutput, creature);

                }
            }
        }

        private Dictionary<Universe, List<Race>> ProcessEntry(Dictionary<Universe, Race[]> races, Creature creature)
        {
            var potentialOutput = new Dictionary<Universe, List<Race>>();

            foreach (var raceKeyValuePair in races)
            {
                Universe currentUniverse = raceKeyValuePair.Key;
                Race[] currentRaces = raceKeyValuePair.Value;


                foreach (var race in currentRaces)
                {

                    
                    if(IsRaceMatchCreature(creature, race))
                    {
                        // Check if the universe already exists in potentialOutput
                        if (!potentialOutput.ContainsKey(currentUniverse))
                            potentialOutput[currentUniverse] = new List<Race> { race };  // If it doesn't exist, add a new entry with a list containing the current race
                        else
                            potentialOutput[currentUniverse].Add(race); // If it exists, add the race to the existing list
                    }
                    

                }

            }
            return potentialOutput;
        }

        private bool IsRaceMatchCreature(Creature creature, Race race)
        {
            if (creature.IsHumanoid != null && creature.IsHumanoid != race.IsHumanoid) return false;
            if (creature.Planet != null && creature.Planet != race.Planet) return false;
            if (creature.Age != 0 && creature.Age > race.Age) return false;
            if (creature.Traits != null && creature.Traits.Any() && (race.Traits == null || creature.Traits.Any(trait => !race.Traits.Contains(trait)))) return false;

            return true;
        }

        private void MatchCreatureToUniverse(Dictionary<Universe, List<Race>> potentialOutput, Creature creature)
        {
            if (potentialOutput.Keys.Count == 1)
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
}