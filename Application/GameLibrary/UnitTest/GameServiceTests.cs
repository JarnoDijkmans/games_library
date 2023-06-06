//using Xunit;
//using Moq;
//using System;
//using DataLayer.DAL;
//using LogicLayer.Interfaces;
//using LogicLayer.Services;
//using LogicLayer.Models.CheckoutRelated;
//using Factory;
//using LogicLayer.Models.GamesFolder;

//public class GameServiceTests
//{
//    private readonly Mock<IGameDAL> _mockGameDal;
//    private readonly GameService _gameService;

//    public GameServiceTests()
//    {
//        _mockGameDal = new Mock<IGameDAL>();
//        _gameService = new GameService(_mockGameDal.Object);
//    }

//    [Fact]
//    public void AddGame_Throws_Exception()
//    {
//        // Arrange
//        //var game = new Game(1, "a", 60, "test", 1990, 6, 6, "test", new List<GameImage>{1, "test","test" }, new List<Genre> {1, "test" }, new List<Feature> { 1, "test" }, new List<Specification> { 1, "test", "test", "test", "test", "test", "test", "test", "test", "test" }, "test");

//        // Assert
//        //Assert.Throws<InvalidOperationException>(() => _gameService.AddGame(game));
//    }

//    [Fact]
//    public void AddGame_Calls_AddGame_Valid()
//    {
//        // Arrange
//        var game = new Game { Title = "Valid Title" };
//        _mockGameDal.Setup(dal => dal.AddGame(game)).Returns(true);

//        // Act
//        var result = _gameService.AddGame(game);

//        // Assert
//        Assert.True(result);
//        _mockGameDal.Verify(dal => dal.AddGame(game), Times.Once);
//    }
//}