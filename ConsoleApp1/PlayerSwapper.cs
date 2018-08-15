namespace TRL
{
    public class PlayerSwapper
    {
        private Player _fromPlayer;
        private Player _toPlayer;

        public PlayerSwapper(Player fromPlayer, Player toPlayer)
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