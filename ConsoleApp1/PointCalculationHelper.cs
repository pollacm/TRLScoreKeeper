using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class PointCalculationHelper
    {
        private const decimal SwapPercentage = 1.6m;
        
        //TODO: get all players for sub package and swap out the highest value
        public static decimal GetPointsForPlayer(Player startingPlayer, Player benchedPlayer)
        {
            var subPackageHelper = new SubPackageHelper();
            if (subPackageHelper.FillsSubPackage(startingPlayer.Position, benchedPlayer.Position))
            {
                return (startingPlayer.Points + benchedPlayer.Points) / 2;
            }

            if (subPackageHelper.PositionsMatch(startingPlayer.Position, benchedPlayer.Position))
            {
                return benchedPlayer.Points;
            }

            return startingPlayer.Points;
        }

        public static bool ShouldSwapByPoints(decimal startingPoints, decimal benchedPoints)
        {
            return startingPoints < benchedPoints * SwapPercentage;
        }
    }
}
