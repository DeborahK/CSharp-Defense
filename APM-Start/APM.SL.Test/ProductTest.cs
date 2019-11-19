using APM.SL;
using System;
using Xunit;

namespace APM.SL.Test
{
  public class ProductTest
  {
    [Fact]
    public void CalculateMargin_WhenValidCost50PercentOfPrice_ShouldReturn50()
    {
      // Arrange
      string cost = "50";
      string price = "100";
      decimal expected = 50;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostOneThirdOfPrice_ShouldRoundTo33()
    {
      // Arrange
      string cost = "100";
      string price = "150";
      decimal expected = 33;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostEqualPrice_ShouldReturn0()
    {
      // Arrange
      string cost = "100";
      string price = "100";
      decimal expected = 0;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostIsMoreThanPrice_ShouldReturnNegative()
    {
      // Arrange
      string cost = "120";
      string price = "100";
      decimal expected = -20;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostLessThan1_ShouldReturn100()
    { 
      // Arrange
      string cost = ".01";
      string price = "100";
      decimal expected = 100M;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostCloseToPrice_ShouldReturn1()
    {
      // Arrange
      string cost = "100";
      string price = "101";
      decimal expected = 1M;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidSmallValues50PercentOfPrice_ShouldReturn50()
    {
      // Arrange
      string cost = ".01";
      string price = ".02";
      decimal expected = 50M;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenValidCostContainsDecimal50PercentOfPrice_ShouldReturn50()
    {
      // Arrange
      string cost = "49.55";
      string price = "100";
      decimal expected = 50M;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

  [Fact]
    public void CalculateMargin_WhenValidCostIsZero_ShouldReturn100()
    {
      // Arrange
      string cost = "0";
      string price = "100";
      decimal expected = 100;

      // Act
      var product = new Product();
      decimal actual = product.CalculateMargin(cost, price);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIs0_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = "0";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIsEmpty_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = "";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostIsEmpty_ShouldGenerateError()
    {
      // Arrange
      string cost = "";
      string price = "100";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The cost must be a number 0 or greater", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIsNotANumber_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = "Hundred";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The price must be a number greater than 0", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostIsNotANumber_ShouldGenerateError()
    {
      // Arrange
      string cost = "Fifty";
      string price = "100";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The cost must be a number 0 or greater", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostContainsDollar_ShouldError()
    {
      // Arrange
      string cost = "$49.95";
      string price = "100";

      // Act
      var product = new Product();
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));

      // Assert
      Assert.Equal("The cost must be a number 0 or greater", ex.Message);
    }
  }
}
