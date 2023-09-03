namespace Minesweeper
{
    public class PlayerService : IPlayerService
    {
        private readonly IGameBoard _gameBoard;

        public PlayerService(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public int Lives { get; set; } = 3;
        public int Moves { get; set; } = 0;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void Move(Direction direction)
        {
            int newX = X;
            int newY = Y;

            switch (direction)
            {
                case Direction.Up:
                    newY--;
                    break;
                case Direction.Down:
                    newY++;
                    break;
                case Direction.Left:
                    newX--;
                    break;
                case Direction.Right:
                    newX++;
                    break;
            }

            if (newX >= 0 && newX < _gameBoard.BoardSize && newY >= 0 && newY < _gameBoard.BoardSize)
            {
                if (_gameBoard.Mines[newY, newX])
                {
                    Lives--;
                }
                else
                {
                    X = newX;
                    Y = newY;
                }

                Moves++;
            }
        }
    }
}
