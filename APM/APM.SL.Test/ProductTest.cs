using APM.SL;
using System;
using Xunit;

namespace APM.SL.Test
{
  public class ProductTest
  {
    [Fact]
    public void CalculateMarginShouldSucceedWhenValidInput50Percent()
    {
      // Arrange
      string costInput = "50";
      string priceInput = "100";
      decimal expected = 50;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSucceedWhenValidInputCostEqualPrice()
    {
      // Arrange
      string costInput = "0";
      string priceInput = "100";
      decimal expected = 100;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSucceedWhenValidInputSmallCost()
    {
      // Arrange
      string costInput = ".01";
      string priceInput = "10";
      decimal expected = 99.9M;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSucceedWhenValidInputLargeCost()
    {
      // Arrange
      string costInput = "100";
      string priceInput = "101";
      decimal expected = .99M;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSucceedWhenValidInputSmallPrice()
    {
      // Arrange
      string costInput = ".01";
      string priceInput = ".02";
      decimal expected = 50M;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldSucceedWhenValidInputLargePrice()
    {
      // Arrange
      string costInput = ".01";
      string priceInput = "100";
      decimal expected = 99.99M;

      // Act
      decimal actual = Product.CalculateMargin(costInput, priceInput);

      // Assert
      Assert.Equal(expected, actual);
    }


    [Fact]
    public void ShouldErrorWhenPriceIs0()
    {
      // Arrange
      string costInput = "50";
      string priceInput = "0";

      // Act
      var ex = Assert.Throws<ArgumentException>(() => Product.CalculateMargin(costInput, priceInput));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void ShouldErrorWhenPriceIsEmpty()
    {
      // Arrange
      string costInput = "50";
      string priceInput = "";

      // Act
      var ex = Assert.Throws<ArgumentException>(() => Product.CalculateMargin(costInput, priceInput));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void ShouldErrorWhenCostIsEmpty()
    {
      // Arrange
      string costInput = "";
      string priceInput = "100";

      // Act
      var ex = Assert.Throws<ArgumentException>(() => Product.CalculateMargin(costInput, priceInput));

      // Assert
      Assert.Equal("The cost must be a number 0 or greater", ex.Message);
    }

    [Fact]
    public void ShouldErrorWhenPriceIsNotANumber()
    {
      // Arrange
      string costInput = "50";
      string priceInput = "Hundred";

      // Act
      var ex = Assert.Throws<ArgumentException>(() => Product.CalculateMargin(costInput, priceInput));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void ShouldErrorWhenCostIsNotANumber()
    {
      // Arrange
      string costInput = "Fifty";
      string priceInput = "100";

      // Act
      var ex = Assert.Throws<ArgumentException>(() => Product.CalculateMargin(costInput, priceInput));

      // Assert
      Assert.Equal("The cost must be a number 0 or greater", ex.Message);
    }

  }
}
