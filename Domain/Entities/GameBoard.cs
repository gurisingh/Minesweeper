namespace Domain.Entities
{
    public class GameBoard
    {
        public GameBoard()
        {
            Mines = new bool[BoardSize, BoardSize];

            Revealed = new bool[BoardSize, BoardSize];

            for (int y = 0; y < BoardSize; y++)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    Mines[y, x] = false;
                    Revealed[y, x] = false;
                }
            }

            var random = new Random();
            int totalMines = BoardSize;

            for (int i = 0; i < totalMines; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, BoardSize);
                    y = random.Next(0, BoardSize);
                }
                while (Mines[y, x]);

                Mines[y, x] = true;
            }
        }

        public int BoardSize { get; set; } = 8;
        public bool[,] Mines { get; set; }
        public bool[,] Revealed { get; set; }
    }
}
