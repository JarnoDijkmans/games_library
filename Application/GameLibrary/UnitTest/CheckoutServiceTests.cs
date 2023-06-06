using Xunit;
using Moq;
using System;
using DataLayer.DAL;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using LogicLayer.Models.CheckoutRelated;
using Factory;

public class CheckoutServiceTests
{
    private readonly Mock<IDiscountDAL> _mockDiscountDal;
    private readonly Mock<IDiscountFactory> _mockDiscountFactory;
    private readonly Mock<IDiscount> _mockDiscount;
    private readonly Mock<ICheckoutDAL> _mockCheckoutDal;
    private readonly CheckoutService _checkoutService;


    public CheckoutServiceTests()
    {
        _mockDiscountDal = new Mock<IDiscountDAL>();
        _mockDiscountFactory = new Mock<IDiscountFactory>();
        _mockDiscount = new Mock<IDiscount>();
        _mockCheckoutDal = new Mock<ICheckoutDAL>();
        _checkoutService = new CheckoutService(_mockDiscountDal.Object, _mockDiscountFactory.Object, _mockCheckoutDal.Object);
    }


    [Fact]
    public void CalculateTotalPrice_With_Null_Discount_Returns_BasePrice()
    {
        // Arrange
        decimal basePrice = 100m;

        // Act
        var totalPrice = _checkoutService.CalculateTotalPrice(basePrice);

        // Assert
        Assert.Equal(basePrice, totalPrice);
    }

    [Fact]
    public void CalculateTotalPrice_With_Discount_Applies_Discount()
    {
        // Arrange
        decimal basePrice = 100m;
        decimal expectedPrice = 90m;
        _mockDiscount.Setup(d => d.ApplyDiscount(basePrice)).Returns(expectedPrice);
        _checkoutService.SetDiscount(_mockDiscount.Object);

        // Act
        var totalPrice = _checkoutService.CalculateTotalPrice(basePrice);

        // Assert
        Assert.Equal(expectedPrice, totalPrice);
    }

    [Fact]
    public void ApplyDiscountByCode_With_Valid_Code_Sets_Discount()
    {
        // Arrange
        string discountCode = "CODE123";
        var discountData = new Discount ( discountCode,"Percentage",10);
        var discount = _mockDiscount.Object;

        _mockDiscountDal.Setup(dal => dal.RetrieveData()).Returns(new List<Discount> { discountData });
        _mockDiscountFactory.Setup(df => df.GetDiscount(discountData.DiscountType, discountData.DiscountValue)).Returns(discount);

        // Act
        var result = _checkoutService.ApplyDiscountByCode(discountCode);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ApplyBirthdayDiscount_Calls_DiscountFactory_And_Sets_Discount()
    {
        // Arrange
        string discountType = "Birthday";
        var discount = _mockDiscount.Object;

        _mockDiscountFactory.Setup(df => df.GetDiscount(discountType, 5)).Returns(discount);

        // Act
        _checkoutService.ApplyBirthdayDiscount(discountType);

        // Assert
        _mockDiscountFactory.Verify(df => df.GetDiscount(discountType, 5), Times.Once);
    }

    [Fact]
    public void CalculateTotalPriceBirthDate_Applies_Birthday_Discount()
    {
        // Arrange
        decimal basePrice = 100m;
        decimal expectedPrice = 90m;
        DateTime birthdate = new DateTime(1990, 6, 6);
        _mockDiscount.Setup(d => d.ApplyBirthdayDiscount(basePrice, birthdate)).Returns(expectedPrice);
        _checkoutService.SetDiscount(_mockDiscount.Object);

        // Act
        var totalPrice = _checkoutService.CalculateTotalPriceBirthDate(basePrice, birthdate);

        // Assert
        Assert.Equal(expectedPrice, totalPrice);
    }

    [Fact]
    public void StorePayment_Calls_GetPaymentById_And_StorePayment()
    {
        // Arrange
        var checkoutInfo = new CheckoutInfo(1, "Ideal", 60m, new List<int> { 1 }, 1, new DateTime(2002, 5, 2));

        // Act
        _checkoutService.StorePayment(checkoutInfo);

        // Assert
        _mockCheckoutDal.Verify(dal => dal.GetPaymentInfoByUserID(Convert.ToInt32(checkoutInfo.userID)), Times.Once);
        _mockCheckoutDal.Verify(dal => dal.StorePayment(checkoutInfo), Times.Once);
    }

    [Fact]
    public void HasUserPurchasedGame_Returns_True()
    {
        // Arrange
        int userId = 1;
        int gameId = 1;
        //Cause of the true statement the mockdata will be true.
        _mockCheckoutDal.Setup(dal => dal.HasUserPurchasedGame(userId, gameId)).Returns(true);

        // Act
        var hasUserPurchasedGame = _checkoutService.HasUserPurchasedGame(userId, gameId);

        // Assert
        Assert.True(hasUserPurchasedGame);
    }

    [Fact]
    public void HasUserPurchasedGame_Returns_False()
    {
        // Arrange
        int userId = 1;
        int gameId = 1;

        //Cause of the false statement the mockdata will be false.
        _mockCheckoutDal.Setup(dal => dal.HasUserPurchasedGame(userId, gameId)).Returns(false);

        // Act
        var hasUserPurchasedGame = _checkoutService.HasUserPurchasedGame(userId, gameId);

        // Assert
        Assert.False(hasUserPurchasedGame);
    }
}