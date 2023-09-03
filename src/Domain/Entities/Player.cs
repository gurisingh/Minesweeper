namespace Domain.Entities
{
    public class Player
    {
        public int Lives { get; set; } = 3;
        public int Moves { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
