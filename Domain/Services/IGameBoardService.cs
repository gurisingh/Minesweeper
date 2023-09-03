using Domain.Entities;

namespace Minesweeper
{
    public interface IGameBoardService
    {

        public void Display(Player player, GameBoard gameBoard);

        public bool IsGameOver(Player player, GameBoard gameBoard);

        public string GetChessPosition(GameBoard gameBoard, int x, int y);
    }
}
