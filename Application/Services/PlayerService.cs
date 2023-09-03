using Domain.Entities;
using Domain.Enums;
using Minesweeper;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        public void Move(Direction direction, GameBoard gameBoard, Player player)
        {
            int newX = player.X;
            int newY = player.Y;

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

            if (newX >= 0 && newX < gameBoard.BoardSize && newY >= 0 && newY < gameBoard.BoardSize)
            {
                if (gameBoard.Mines[newY, newX])
                {
                    player.Lives--;
                }
                else
                {
                    player.X = newX;
                    player.Y = newY;
                }

                player.Moves++;
            }
        }
    }
}
