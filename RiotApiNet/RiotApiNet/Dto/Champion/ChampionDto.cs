using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiNet.Dto.Champion
{
    public class ChampionDto
    {
        public bool Active { get; set; }
        public bool BotEnabled { get; set; }
        public bool BotMmEnabled { get; set; }
        public bool FreeToPlay { get; set; }
        public long Id { get; set; }
        public bool RankedPlayEnabled { get; set; }
    }
}
