namespace TRL
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PositionEnum Position { get; set; }
        public decimal Points { get; set; }
        public decimal PointsUpdated { get; set; }
        public bool Starting { get; set; }
        public bool AlreadySubbed { get; set; }
        public int OriginalIndex { get; set; }
    }
}
