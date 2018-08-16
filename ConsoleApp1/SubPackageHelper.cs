using System.Collections.Generic;

namespace TRLScoreKeeper
{
    public class SubPackageHelper
    {
        private readonly Dictionary<PositionEnum, List<PositionEnum>> _subPackages = new Dictionary<PositionEnum, List<PositionEnum>>();

        public SubPackageHelper()
        {
            _subPackages.Add(PositionEnum.QB, new List<PositionEnum>{});
            _subPackages.Add(PositionEnum.K, new List<PositionEnum>{});
            _subPackages.Add(PositionEnum.RB, new List<PositionEnum>{PositionEnum.WR, PositionEnum.TE});
            _subPackages.Add(PositionEnum.WR, new List<PositionEnum>{PositionEnum.RB, PositionEnum.TE});
            _subPackages.Add(PositionEnum.TE, new List<PositionEnum>{PositionEnum.RB, PositionEnum.WR});
            _subPackages.Add(PositionEnum.DL, new List<PositionEnum>{PositionEnum.LB, PositionEnum.DB});
            _subPackages.Add(PositionEnum.LB, new List<PositionEnum> { PositionEnum.DB, PositionEnum.DL });
            _subPackages.Add(PositionEnum.DB, new List<PositionEnum> { PositionEnum.LB, PositionEnum.DL });
        }

        public bool FillsSubPackage(PositionEnum startingPosition, PositionEnum benchedPosition)
        {
            return _subPackages[startingPosition].Contains(benchedPosition);
        }

        public bool PositionsMatch(PositionEnum startingPosition, PositionEnum benchedPosition)
        {
            return startingPosition == benchedPosition;
        }
    }
}
