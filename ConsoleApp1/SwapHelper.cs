using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SwapHelper
    {
        public Player[] GetUpdatedPlayers(Player[] playersForRosterInput)
        {
            var playersForRosterSorted =  playersForRosterInput
                                            .OrderBy(p => p.Position)
                                            .ThenByDescending(p => p.Points)
                                            .ThenByDescending(p => p.Starting).ToArray();

            var starters = playersForRosterSorted.Where(p => p.Starting);
            var benchPlayers = playersForRosterSorted.Where(p => !p.Starting);

            var indexOfStarter = 0;
            foreach(var starter in starters)
            {
                var swappedStarter = false;
                var playerToStart = starter;
                var playerToBench = new Player();

                var indexOfBenchPlayer = 0;
                foreach(var benchPlayer in benchPlayers)
                {
                    if(ShouldSwapPlayer(starter, benchPlayer))
                    {
                        swappedStarter = true;
                        playerToStart = new PlayerSwapper(starter, benchPlayer).SwapPlayer();
                        playerToBench = new PlayerSwapper(benchPlayer, starter).SwapPlayer();
                        break;
                    }
                }
                playersForRosterSorted[indexOfStarter] = playerToStart;
                if(swappedStarter)
                {
                    playersForRosterSorted[indexOfStarter + indexOfBenchPlayer] = playerToBench;
                }
            }

            return playersForRosterSorted;
        }

        private bool ShouldSwapPlayer(Player startingPlayer, Player benchPlayer)
        {
            var shouldSwap = false;
            var subPackageHelper = new SubPackageHelper();
            if (StartersStartBenchBenched(startingPlayer, benchPlayer) && 
                subPackageHelper.FillsSubPackage(startingPlayer.Position, benchPlayer.Position) && 
                PointCalculationHelper.ShouldSwapByPoints(startingPlayer.Points, benchPlayer.Points))
            {
                shouldSwap = true;
            }

            return shouldSwap;
        }

        private static bool StartersStartBenchBenched(Player startingPlayer, Player benchPlayer)
        {
            return startingPlayer.Starting && !benchPlayer.Starting;
        }
    }
}
