using Domain.Entities;
using Domain.Enums;

namespace Minesweeper
{
    public class Game
    {
        private readonly IGameBoardService _gameBoardService;
        private readonly IPlayerService _playerService;

        public Game(IGameBoardService gameBoardService, IPlayerService playerService)
        {
            _playerService = playerService;
            _gameBoardService = gameBoardService;
        }

        public void Start()
        {
            Console.Clear();

            var player = new Player();

            var gameBoard = new GameBoard();

            while (!_gameBoardService.IsGameOver(player, gameBoard))
            {
                _gameBoardService.Display(player, gameBoard);

                Console.Write("Enter direction (Up, Down, Left, Right): ");

                var input = Console.ReadLine();

                if (Enum.TryParse<Direction>(input, true, out var direction))
                {
                    _playerService.Move(direction, gameBoard, player);
                }
            }

            Console.WriteLine("Game Finished!");

            Console.WriteLine($"Lives: {player.Lives}, Moves: {player.Moves}, Position: {_gameBoardService.GetChessPosition(gameBoard, player.X, player.Y)}");

        }
    }
}
