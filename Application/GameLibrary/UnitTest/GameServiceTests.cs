using Xunit;
using Moq;
using System;
using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using LogicLayer.Models.CheckoutRelated;
using Factory;
using LogicLayer.Models.GamesFolder;

public class GameServiceTests
{
    private readonly Mock<IGameDAL> _mockGameDal;
    private readonly GameService _gameService;

    public GameServiceTests()
    {
        _mockGameDal = new Mock<IGameDAL>();
        _gameService = new GameService(_mockGameDal.Object);
    }

    [Fact]
    public void CreateGame_WithEmptyTitle_ThrowsException()
    {
        // Arrange
        Action createGame = () => new Game(
            1,
            "", // empty title
            60m,
            "test",
            "1990-05-01",
            "test",
            new List<GameImage> { new GameImage(1, "test", "\\Images\\.png") },
            new List<Genre> { new Genre(1, "test") },
            new List<Feature> { new Feature(1, "test") },
            new List<Specification> { new Specification(1, "test", "test", "test", "test", "test", "test", "test", "test", "test") },
            "test"
        );

        // Assert
        Assert.Throws<ArgumentException>(createGame);
    }

    [Fact]
    public void AddGame_Calls_AddGame_Valid()
    {
        // Arrange
        var game = new Game(
                1,
                "Valid Title",
                60m,
                "test",
                "1990-05-01",
                "test",
                new List<GameImage> { new GameImage(1, "test", "\\Images\\.png") },
                new List<Genre> { new Genre(1, "test") },
                new List<Feature> { new Feature(1, "test") },
                new List<Specification> { new Specification(1, "test", "test", "test", "test", "test", "test", "test", "test", "test") },
                "test"
                );
        _mockGameDal.Setup(dal => dal.AddGame(game)).Returns(true);

        // Act
        var result = _gameService.AddGame(game);

        // Assert
        Assert.True(result);
        _mockGameDal.Verify(dal => dal.AddGame(game), Times.Once);
    }
    [Fact]
    public void GetGameById_ReturnsCorrectGame()
    {
        // Arrange
        var expectedGame = new Game(1, "Game1", 60m, "test", "1990-05-01", "test", new List<GameImage>(), new List<Genre>(), new List<Feature>(), new List<Specification>(), "test");
        _mockGameDal.Setup(dal => dal.GetGameById(1)).Returns(expectedGame);

        // Act
        var actualGame = _gameService.GetGameById(1);

        // Assert
        Assert.Equal(expectedGame, actualGame);
    }

    [Fact]
    public void SearchGames_ReturnsCorrectGames()
    {
        // Arrange
        var expectedGames = new List<Game> { new Game(1, "Game1", 60m, "test", "1990-05-01", "test", new List<GameImage>(), new List<Genre>(), new List<Feature>(), new List<Specification>(), "test") };
        _mockGameDal.Setup(dal => dal.SearchGames("Game1")).Returns(expectedGames);

        // Act
        var actualGames = _gameService.SearchGames("Game1");

        // Assert
        Assert.Equal(expectedGames, actualGames);
    }

    [Fact]
    public void GetGenres_ReturnsCorrectGenres()
    {
        // Arrange
        var expectedGenres = new List<Genre> { new Genre(1, "Genre1") };
        _mockGameDal.Setup(dal => dal.GetAllGenres()).Returns(expectedGenres);

        // Act
        var actualGenres = _gameService.GetGenres();

        // Assert
        Assert.Equal(expectedGenres, actualGenres);
    }

    [Fact]
    public void GetGenreIdByName_ReturnsCorrectId()
    {
        // Arrange
        var genres = new List<Genre> { new Genre(1, "Genre1") };
        _mockGameDal.Setup(dal => dal.GetAllGenres()).Returns(genres);

        // Act
        var genreId = _gameService.GetGenreIdByName("Genre1");

        // Assert
        Assert.Equal(1, genreId);
    }

    [Fact]
    public void GetFeatures_ReturnsCorrectFeatures()
    {
        // Arrange
        var expectedFeatures = new List<Feature> { new Feature(1, "Feature1") };
        _mockGameDal.Setup(dal => dal.GetAllFeatures()).Returns(expectedFeatures);

        // Act
        var actualFeatures = _gameService.GetFeatures();

        // Assert
        Assert.Equal(expectedFeatures, actualFeatures);
    }

    [Fact]
    public void UpdateGame_ReturnsTrue_WhenUpdateSucceeds()
    {
        // Arrange
        var gameToUpdate = new Game(1, "Game1", 60m, "test", "1990-05-01", "test", new List<GameImage>(), new List<Genre>(), new List<Feature>(), new List<Specification>(), "test");
        _mockGameDal.Setup(dal => dal.UpdateGame(gameToUpdate)).Returns(true);

        // Act
        var result = _gameService.UpdateGame(gameToUpdate);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetFeatureIdByName_ReturnsCorrectId()
    {
        // Arrange
        var features = new List<Feature> { new Feature(1, "Feature1") };
        _mockGameDal.Setup(dal => dal.GetAllFeatures()).Returns(features);

        // Act
        var featureId = _gameService.GetFeatureIdByName("Feature1");

        // Assert
        Assert.Equal(1, featureId);
    }
}