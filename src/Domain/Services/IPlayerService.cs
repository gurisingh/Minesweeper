using Domain.Entities;
using Domain.Enums;

namespace Minesweeper
{
    public interface IPlayerService
    {
        public void Move(Direction direction, GameBoard gameBoard, Player player);
    }
}
