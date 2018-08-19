namespace TRL
{
    public class PlayerMapper
    {
        private readonly Player _fromPlayer;
        private readonly Player _toPlayer;

        public PlayerMapper(Player fromPlayer, Player toPlayer)
        {
            _fromPlayer = fromPlayer;
            _toPlayer = toPlayer;
        }

        public Player SwapPlayer()
        {
            return new Player
            {
                FirstName = _toPlayer.FirstName,
                LastName = _toPlayer.LastName,
                Position = _toPlayer.Position,
                PointsUpdated = PointCalculationHelper.GetPointsForPlayer(_fromPlayer, _toPlayer),
                Points = _toPlayer.Points,
                Starting = _fromPlayer.Starting,
                OriginalIndex = _toPlayer.OriginalIndex,
                AlreadySubbed = true
            };
        }
    }
}