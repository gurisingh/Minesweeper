using Domain.Entities;
using Minesweeper;

namespace Application.Services
{
    public class GameBoardService : IGameBoardService
    {

        public void Display(Player player, GameBoard gameBoard)
        {
            Console.WriteLine("Game Board:");
            var currentPosition = string.Empty;

            for (int y = 0; y < gameBoard.BoardSize; y++)
            {
                for (int x = 0; x < gameBoard.BoardSize; x++)
                {
                    var position = GetChessPosition(gameBoard, x, y);

                    if (x == player.X && y == player.Y)
                    {
                        Console.Write($"P ");
                        currentPosition = position;
                    }
                    else if (gameBoard.Revealed[y, x])
                    {
                        if (gameBoard.Mines[y, x])
                        {
                            Console.Write($"* ");
                        }
                        else
                        {
                            Console.Write($". ");
                        }
                    }
                    else
                    {
                        Console.Write($"? ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Lives: {player.Lives} Moves: {player.Moves} Position: {currentPosition}");

        }

        public string GetChessPosition(GameBoard gameBoard, int x, int y)
        {
            char column = (char)('A' + x);
            int row = gameBoard.BoardSize - y;

            if (x >= 0 && x < gameBoard.BoardSize && y >= 0 && y < gameBoard.BoardSize)
            {
                return $"{column}{row}";
            }
            else
            {
                return "InvalidPosition";
            }
        }

        public bool IsGameOver(Player player, GameBoard gameBoard)
        {
            return player.Lives <= 0 || player.X == gameBoard.BoardSize - 1 && !gameBoard.Mines[player.Y, player.X];
        }
    }
}
