using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRLScoreKeeper
{
    public class SwapHelper
    {
        public Player[] GetUpdatedPlayers(Player[] playersForRosterInput)
        {
            var playersForRosterSorted =  playersForRosterInput
                                            .OrderBy(p => p.Position)
                                            .ThenByDescending(p => p.Starting)
                                            .ThenByDescending(p => p.Points).ToArray();

            playersForRosterSorted = SwapPlayersPrimaryPosition(playersForRosterSorted);
            playersForRosterSorted = SwapPlayersSubPackage(playersForRosterSorted);

            return playersForRosterSorted;
        }

        private Player[] SwapPlayersPrimaryPosition(Player[] playersForRosterSorted)
        {
            var starters = playersForRosterSorted.Where(p => p.Starting && !p.AlreadySubbed);
            var benchPlayers = playersForRosterSorted.Where(p => !p.Starting && !p.AlreadySubbed);

            var indexOfStarter = 0;
            foreach (var starter in starters)
            {
                var swappedStarter = false;
                var playerToStart = starter;
                var playerToBench = new Player();

                var indexOfBenchPlayer = 0;

                foreach (var benchPlayer in benchPlayers)
                {
                    if (ShouldSwapPlayerPrimaryPosition(starter, benchPlayer))
                    {
                        swappedStarter = true;
                        playerToStart = new PlayerSwapper(starter, benchPlayer).SwapPlayer();
                        playerToBench = new PlayerSwapper(benchPlayer, starter).SwapPlayer();
                        break;
                    }                    
                }
                playersForRosterSorted[indexOfStarter] = playerToStart;
                if (swappedStarter)
                {
                    playersForRosterSorted[starters.Count() + 1 + indexOfBenchPlayer] = playerToBench;
                }
                indexOfStarter++;
            }

            return playersForRosterSorted;
        }

        private Player[] SwapPlayersSubPackage(Player[] playersForRosterSorted)
        {
            var starters = playersForRosterSorted.Where(p => p.Starting && !p.AlreadySubbed);
            var benchPlayers = playersForRosterSorted.Where(p => !p.Starting && !p.AlreadySubbed);

            var indexOfStarter = 0;
            foreach (var starter in starters)
            {
                var swappedStarter = false;
                var playerToStart = starter;
                var playerToBench = new Player();

                var indexOfBenchPlayer = 0;

                foreach (var benchPlayer in benchPlayers)
                {
                    if (ShouldSwapPlayerSubPackage(starter, benchPlayer))
                    {
                        swappedStarter = true;
                        playerToStart = new PlayerSwapper(starter, benchPlayer).SwapPlayer();
                        playerToBench = new PlayerSwapper(benchPlayer, starter).SwapPlayer();
                        break;
                    }
                }
                playersForRosterSorted[indexOfStarter] = playerToStart;
                if (swappedStarter)
                {
                    playersForRosterSorted[starters.Count() + indexOfBenchPlayer] = playerToBench;
                }
                indexOfStarter++;
            }

            return playersForRosterSorted;
        }

        private bool ShouldSwapPlayerPrimaryPosition(Player startingPlayer, Player benchPlayer)
        {
            var shouldSwap = false;
            var subPackageHelper = new SubPackageHelper();
            if (StartersStartBenchBenched(startingPlayer, benchPlayer) && 
                subPackageHelper.PositionsMatch(startingPlayer.Position, benchPlayer.Position) && 
                PointCalculationHelper.ShouldSwapByPoints(startingPlayer.Points, benchPlayer.Points))
            {
                shouldSwap = true;
            }

            return shouldSwap;
        }

        private bool ShouldSwapPlayerSubPackage(Player startingPlayer, Player benchPlayer)
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
