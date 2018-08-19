using System;
using System.Linq;

namespace TRL
{
    public class PlayerSwapper
    {
        public Player[] GetUpdatedPlayers(Player[] playersForRosterInput)
        {
            //var playersForRosterSorted = playersForRosterInput.OrderBy(p => p.OriginalIndex).ToArray();
            //.OrderBy(p => p.Position)
            //.ThenByDescending(p => p.Starting)
            //.ThenByDescending(p => p.Points).ToArray();

            var playersForRosterSorted = playersForRosterInput.Where(p => p.Starting).OrderBy(p => p.Points).ToList();
            playersForRosterSorted.AddRange(playersForRosterInput.Where(p => !p.Starting).OrderByDescending(p => p.Points).ToList());

            var playersForRosterSortedArray = playersForRosterSorted.ToArray();
            playersForRosterSortedArray = SwapPlayersPrimaryPosition(playersForRosterSortedArray);
            playersForRosterSortedArray = SwapPlayersSubPackage(playersForRosterSortedArray);

            return playersForRosterSortedArray;
        }

        private Player[] SwapPlayersPrimaryPosition(Player[] playersForRosterSorted)
        {
            var starters = playersForRosterSorted.Where(p => p.Starting && !p.AlreadySubbed).ToList();
            var benchPlayers = playersForRosterSorted.Where(p => !p.Starting && !p.AlreadySubbed).ToList();

            var indexOfStarter = 0;
            foreach (var starter in starters)
            {
                var shouldSwapPlayer = false;
                var playerToStart = starter;
                var playerToBench = new Player();

                var indexOfBenchPlayer = 0;

                foreach (var benchPlayer in benchPlayers)
                {
                    if (ShouldSwapPlayerPrimaryPosition(starter, benchPlayer) && !AlreadySubbedBenchPlayer(benchPlayer, playersForRosterSorted))
                    {
                        shouldSwapPlayer = true;
                        playerToStart = new PlayerMapper(starter, benchPlayer).SwapPlayer();
                        playerToBench = new PlayerMapper(benchPlayer, starter).SwapPlayer();
                        break;
                    }

                    indexOfBenchPlayer++;
                }
                
                if (shouldSwapPlayer)
                {
                    playersForRosterSorted[indexOfStarter] = playerToStart;
                    playersForRosterSorted[starters.Count + indexOfBenchPlayer] = playerToBench;
                }

                indexOfStarter++;
            }

            return playersForRosterSorted;
        }

        private Player[] SwapPlayersSubPackage(Player[] playersForRosterSorted)
        {
            var starters = playersForRosterSorted.Where(p => p.Starting && !p.AlreadySubbed).ToList();
            var benchPlayers = playersForRosterSorted.Where(p => !p.Starting && !p.AlreadySubbed).ToList();

            var indexOfStarter = 0;
            foreach (var starter in starters)
            {
                var shouldSwapPlayer = false;
                var playerToStart = starter;
                var playerToBench = new Player();

                var indexOfBenchPlayer = 0;

                foreach (var benchPlayer in benchPlayers)
                {
                    if (ShouldSwapPlayerSubPackage(starter, benchPlayer) && !AlreadySubbedBenchPlayer(benchPlayer, playersForRosterSorted))
                    {
                        shouldSwapPlayer = true;
                        playerToStart = new PlayerMapper(starter, benchPlayer).SwapPlayer();
                        playerToBench = new PlayerMapper(benchPlayer, starter).SwapPlayer();
                        break;
                    }

                    indexOfBenchPlayer++;
                }

                if (shouldSwapPlayer)
                {
                    playersForRosterSorted[indexOfStarter] = playerToStart;
                    playersForRosterSorted[starters.Count + indexOfBenchPlayer] = playerToBench;
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
                shouldSwap = true;

            return shouldSwap;
        }

        private bool ShouldSwapPlayerSubPackage(Player startingPlayer, Player benchPlayer)
        {
            var shouldSwap = false;
            var subPackageHelper = new SubPackageHelper();
            if (StartersStartBenchBenched(startingPlayer, benchPlayer) &&
                subPackageHelper.FillsSubPackage(startingPlayer.Position, benchPlayer.Position) &&
                PointCalculationHelper.ShouldSwapByPoints(startingPlayer.Points, benchPlayer.Points))
                shouldSwap = true;

            return shouldSwap;
        }

        private static bool StartersStartBenchBenched(Player startingPlayer, Player benchPlayer)
        {
            return startingPlayer.Starting && !benchPlayer.Starting;
        }

        private bool AlreadySubbedBenchPlayer(Player benchPlayer, Player[] playersForRosterSorted)
        {
            var result = playersForRosterSorted.Any(p => p.FirstName == benchPlayer.FirstName && p.LastName == benchPlayer.LastName && p.Position == benchPlayer.Position && p.AlreadySubbed);

            return result;
        }
    }
}