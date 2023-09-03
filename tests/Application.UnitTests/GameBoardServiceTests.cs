using Application.Services;
using Domain.Entities;

namespace Application.UnitTests
{
    public class GameBoardServiceTests
    {
        [Fact]
        public void GetChessPosition_ShouldReturnA1_WhenXIs0AndYIs7()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var service = new GameBoardService();

            // Act
            var result = service.GetChessPosition(gameBoard, 0, 7);

            // Assert
            Assert.Equal("A1", result);
        }

        [Fact]
        public void GetChessPosition_ShouldReturnH8_WhenXIs7AndYIs0()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var service = new GameBoardService();

            // Act
            var result = service.GetChessPosition(gameBoard, 7, 0);

            // Assert
            Assert.Equal("H8", result);
        }

        [Fact]
        public void GetChessPosition_ShouldReturnD4_WhenXIs3AndYIs3()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var service = new GameBoardService();

            // Act
            var result = service.GetChessPosition(gameBoard, 3, 3);

            // Assert
            Assert.Equal("D5", result);
        }

        [Fact]
        public void GetChessPosition_ShouldReturnInvalidPosition_WhenXIsNegative()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var service = new GameBoardService();

            // Act
            var result = service.GetChessPosition(gameBoard, -1, 5);

            // Assert
            Assert.Equal("InvalidPosition", result);
        }

        [Fact]
        public void GetChessPosition_ShouldReturnInvalidPosition_WhenYIsOutOfRange()
        {
            // Arrange
            var gameBoard = new GameBoard();
            var service = new GameBoardService();

            // Act
            var result = service.GetChessPosition(gameBoard, 2, 10);

            // Assert
            Assert.Equal("InvalidPosition", result);
        }
    }
}