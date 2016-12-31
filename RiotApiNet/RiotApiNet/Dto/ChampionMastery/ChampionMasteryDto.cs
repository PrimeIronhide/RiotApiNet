using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiNet.Dto.ChampionMastery
{
    public class ChampionMasteryDto
    {
        public long ChampionId { get; set; }
        public int ChampionLevel { get; set; }
        public int ChampionPoints { get; set; }
        public long ChampionPointsSinceLastLevel { get; set; }
        public long ChampionPointsUntilNextLevel { get; set; }
        public bool ChestGranted { get; set; }
        public long LastPlayTime { get; set; }
        public long PlayerId { get; set; }
    }
}
