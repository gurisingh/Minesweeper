using Application.Services;
using Domain.Entities;
using Domain.Enums;

namespace Application.UnitTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void Move_ShouldDecreaseLives_WhenPlayerHitsMine()
        {
            // Arrange
            var player = new Player { X = 1, Y = 1, Lives = 3 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Set a mine at the new position (1, 0) to simulate hitting a mine
            gameBoard.Mines[0, 1] = true;

            // Act
            playerService.Move(Direction.Up, gameBoard, player);

            // Assert
            Assert.Equal(2, player.Lives);
        }

        [Fact]
        public void Move_ShouldIncreaseMoves_WhenPlayerMoves()
        {
            // Arrange
            var player = new Player { X = 1, Y = 1, Lives = 3, Moves = 0 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act
            playerService.Move(Direction.Right, gameBoard, player);

            // Assert
            Assert.Equal(1, player.Moves); // Check that moves increased
        }

        [Fact]
        public void Move_ShouldNotChangeLives_WhenPlayerMovesWithoutHittingMine()
        {
            // Arrange
            var player = new Player { X = 1, Y = 1, Lives = 3 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act
            playerService.Move(Direction.Right, gameBoard, player);

            // Assert
            Assert.Equal(3, player.Lives); // Check that lives remained the same
        }

        [Fact]
        public void Move_ShouldNotChangeMoves_WhenPlayerStaysInPlace()
        {
            // Arrange
            var player = new Player { X = 0, Y = 0, Lives = 3, Moves = 0 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act
            playerService.Move(Direction.Left, gameBoard, player);

            // Assert
            Assert.Equal(0, player.Moves); // Check that moves remained the same
        }

        [Fact]
        public void Move_ShouldNotChangeLives_WhenPlayerMovesOutofBounds()
        {
            // Arrange
            var player = new Player { X = 0, Y = 0, Lives = 3 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act (Move left, which is out of bounds)
            playerService.Move(Direction.Left, gameBoard, player);

            // Assert
            Assert.Equal(3, player.Lives); // Check that lives remained the same
        }

        [Fact]
        public void Move_ShouldNotChangeMoves_WhenPlayerMovesOutofBounds()
        {
            // Arrange
            var player = new Player { X = 0, Y = 0, Lives = 3, Moves = 0 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act (Move up, which is out of bounds)
            playerService.Move(Direction.Up, gameBoard, player);

            // Assert
            Assert.Equal(0, player.Moves); // Check that moves remained the same
        }

        [Fact]
        public void Move_ShouldNotChangeLives_WhenPlayerMovesToValidCell()
        {
            // Arrange
            var player = new Player { X = 1, Y = 1, Lives = 3 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act (Move to a valid empty cell)
            playerService.Move(Direction.Right, gameBoard, player);

            // Assert
            Assert.Equal(3, player.Lives); // Check that lives remained the same
        }

        [Fact]
        public void Move_ShouldNotChangeMoves_WhenPlayerMovesToValidCell()
        {
            // Arrange
            var player = new Player { X = 1, Y = 1, Lives = 3, Moves = 0 };
            var gameBoard = new GameBoard();
            var playerService = new PlayerService();

            // Act (Move to a valid empty cell)
            playerService.Move(Direction.Right, gameBoard, player);

            // Assert
            Assert.Equal(1, player.Moves); // Check that moves increased
        }
    }
}