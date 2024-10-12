using System;
using System.Text.Json.Nodes;

namespace Csharp
{
    class Repartition
    {

        public void ToUniverse(JsonArray? data, Dictionary<Universe, Race[]> races, Dictionary<string, Universe> universes)
        {
            if (data != null)
            {
                foreach (var entry in data)
                {
                    Creature creature = new Creature();
                    creature.DataToCreature(entry);

                    ProcessEntry(races, creature, universes);

                }
            }
        }

        private void ProcessEntry(Dictionary<Universe, Race[]> races, Creature creature, Dictionary<string, Universe> universes)
        {
            var potentialOutput = new Dictionary<Universe, List<Race>>();

            foreach (var raceKeyValuePair in races)
            {
                Universe currentUniverse = raceKeyValuePair.Key;
                Race[] currentRaces = raceKeyValuePair.Value;


                foreach (var race in currentRaces)
                {


                    if (IsRaceMatchCreature(creature, race))
                    {
                        universes[currentUniverse.Name].Individuals.Add(creature);
                    }


                }

            }

        }

        private bool IsRaceMatchCreature(Creature creature, Race race)
        {
            if (creature.IsHumanoid != null && creature.IsHumanoid != race.IsHumanoid) return false;
            if (creature.Planet != null && creature.Planet != race.Planet) return false;
            if (creature.Age != 0 && creature.Age > race.Age) return false;
            if (creature.Traits != null && creature.Traits.Any() && (race.Traits == null || creature.Traits.Any(trait => !race.Traits.Contains(trait)))) return false;

            return true;
        }
    }
}