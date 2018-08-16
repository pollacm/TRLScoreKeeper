using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRLScoreKeeper
{
    public class Team
    {
        public Player QuarterBack { get; set; }
        public Player WideReceiver { get; set; }
        public Player RunningBack { get; set; }
        public Player TightEnd { get; set; }
        public List<Player> Flex { get; set; }
        public Player Kicker { get; set; }
        public Player DefensiveLineman { get; set; }
        public Player Linebacker { get; set; }
        public Player DefensiveBack { get; set; }
        public Player Defense { get; set; }
        public List<Player> Bench { get; set; }
    }
}
