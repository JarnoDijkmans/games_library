using Xunit;
using Moq;
using System;
using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using LogicLayer.Models.CheckoutRelated;
using Factory;
using LogicLayer.Models.CartRelated;
using LogicLayer.Models.GamesFolder;

public class CheckoutServiceTests
{
    private readonly Mock<IDiscountDAL> _discountDalMock;
    private readonly Mock<ICheckoutDAL> _checkoutDalMock;
    private readonly Mock<DiscountStrategyFactory> _strategyFactoryMock;

    public CheckoutServiceTests()
    {
        _discountDalMock = new Mock<IDiscountDAL>();
        _checkoutDalMock = new Mock<ICheckoutDAL>();
        _strategyFactoryMock = new Mock<DiscountStrategyFactory>();
    }

    [Fact]
    public void ApplyDiscount_Birthday_Discount_Applied()
    {
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        var birthdate = DateTime.UtcNow;
        var result = service.ApplyDiscount(null, 100m, birthdate);

        Assert.True(result < 100m);
    }

    [Fact]
    public void ApplyDiscount_CodeDiscount_Discount_Applied()
    {
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        _discountDalMock.Setup(x => x.GetDiscountByCode("code")).Returns(new Discount ("code", "type", 1));

        var result = service.ApplyDiscount("code", 100m, DateTime.UtcNow);

        Assert.True(result < 100m);
    }

    [Fact]
    public void HasUserPurchasedGame_UserHasPurchasedGame_ReturnsTrue()
    {
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        _checkoutDalMock.Setup(x => x.HasUserPurchasedGame(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

        var result = service.HasUserPurchasedGame(1, 1);

        Assert.True(result);
    }

    [Fact]
    public void GetPaymentById_WithValidId_ReturnsPaymentInfo()
    {
        // Arrange
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        var checkoutInfos = new List<CheckoutInfo> { new CheckoutInfo() };
        _checkoutDalMock.Setup(x => x.GetPaymentInfoByUserID(It.IsAny<int>())).Returns(checkoutInfos);

        // Act
        var result = service.GetPaymentById(1);

        // Assert
        Assert.Equal(checkoutInfos, result);
    }

    [Fact]
    public void StorePayment_ValidPayment_ReturnsTrue()
    {
        // Arrange
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        _checkoutDalMock.Setup(x => x.StorePayment(It.IsAny<CheckoutInfo>())).Returns(true);

        // Act
        var result = service.StorePayment(new CheckoutInfo());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CalculateSubtotal_ValidCart_ReturnsCorrectSubtotal_And_Validates_GameObject()
    {
        // Arrange
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);
        var cart = new CartViewModel
        {
            GamesInCart = new List<Game>
            {
               new Game(
                1,
                "a",
                60m,
                "test",
                "1990-05-01",
                "test",
                new List<GameImage>{ new GameImage(1, "test", "\\Images\\.png") },
                new List<Genre>{ new Genre(1, "test") },
                new List<Feature>{ new Feature(1, "test") },
                new List<Specification>{ new Specification(1, "test", "test", "test", "test", "test", "test", "test", "test", "test") },
                "test"
                ),
               new Game(
                2,
                "b",
                25m,
                "test",
                "1990-05-01",
                "test",
                new List<GameImage>{ new GameImage(2, "test", "\\Images\\.png") },
                new List<Genre>{ new Genre(2, "test") },
                new List<Feature>{ new Feature(2, "test") },
                new List<Specification>{ new Specification(2, "test", "test", "test", "test", "test", "test", "test", "test", "test") },
                "test"
                ),
               new Game(
                3,
                "c",
                15m,
                "test",
                "1990-05-01",
                "test",
                new List<GameImage>{ new GameImage(3, "test","\\Images\\.png") },
                new List<Genre>{ new Genre(3, "test") },
                new List<Feature>{ new Feature(3, "test") },
                new List<Specification>{ new Specification(3, "test", "test", "test", "test", "test", "test", "test", "test", "test") },
                "test"
                )
            }
        };

        // Act
        var result = service.CalculateSubtotal(cart);

        // Assert
        Assert.Equal(100m, result);
    }

    [Fact]
    public void CalculateAmountDiscount_ValidPrices_ReturnsCorrectDiscount()
    {
        // Arrange
        var service = new CheckoutService(_strategyFactoryMock.Object, _discountDalMock.Object, _checkoutDalMock.Object);

        // Act
        var result = service.CalculateAmountDiscount(100m, 90m);

        // Assert
        Assert.Equal(10m, result);
    }
}
