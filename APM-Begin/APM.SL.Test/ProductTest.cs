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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act
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
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("The price must be a number greater than 0 (Parameter 'price')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIsEmpty_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = "";
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("Please enter the price (Parameter 'price')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostIsEmpty_ShouldGenerateError()
    {
      // Arrange
      string cost = "";
      string price = "100";
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("Please enter the cost (Parameter 'cost')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIsNull_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = null;
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("Please enter the price (Parameter 'price')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostIsNull_ShouldGenerateError()
    {
      // Arrange
      string cost = null;
      string price = "100";
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("Please enter the cost (Parameter 'cost')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidPriceIsNotANumber_ShouldGenerateError()
    {
      // Arrange
      string cost = "50";
      string price = "Hundred";
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("The price must be a number greater than 0 (Parameter 'price')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostIsNotANumber_ShouldGenerateError()
    {
      // Arrange
      string cost = "Fifty";
      string price = "100";
      var product = new Product();

      // Act
      Action act = () => product.CalculateMargin(cost, price);

      // Assert
      var ex = Assert.Throws<ArgumentException>(act);
      Assert.Equal("The cost must be a number 0 or greater (Parameter 'cost')", ex.Message);
    }

    [Fact]
    public void CalculateMargin_WhenInvalidCostContainsDollar_ShouldError()
    {
      // Arrange
      string cost = "$49.95";
      string price = "100";
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
      Assert.Equal("The cost must be a number 0 or greater (Parameter 'cost')", ex.Message);
    }



    //
    // CalculateTotalDiscount
    //
    [Fact]
    public void CalculateTotalDiscount_WhenDiscount50_ShouldReturnHalf()
    {
      // Arrange
      var price = 200;
      var discount = new Discount()
      {
        PercentOff = 50
      };
      var product = new Product();
      var expected = 100;

      // Act
      var actual = product.CalculateTotalDiscount(price, discount);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateTotalDiscount_WhenDiscount25_ShouldReturnQuarter()
    {
      // Arrange
      var price = 200;
      var discount = new Discount()
      {
        PercentOff = 25
      };
      var product = new Product();
      var expected = 50;

      // Act
      var actual = product.CalculateTotalDiscount(price, discount);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void CalculateTotalDiscount_WhenDiscountNull_ShouldReturnError()
    {
      // Arrange
      var price = 200;
      Discount discount = null;
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateTotalDiscount(price, discount));
      Assert.Equal("Please specify a discount", ex.Message);
    }

    [Fact]
    public void CalculateTotalDiscount_WhenPriceIs0_ShouldReturnError()
    {
      // Arrange
      var price = 0;
      var discount = new Discount()
      {
        PercentOff = 50
      };
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.CalculateTotalDiscount(price, discount));
      Assert.Equal("Please enter the price", ex.Message);
    }

    //
    // SavePrice
    //
    [Fact]
    public void SavePrice_WhenAllValid_ShouldReturnTrue()
    {
      // Arrange
      var product = new Product();
      var expected = true;

      // Act
      var actual = product.SavePrice(1, "200", "100",
                                     "GAM", "Increased cost",
                                     DateTime.Now.AddDays(10));

      // Assert
      Assert.Equal(expected, actual);
    }

    //
    // ValidateEffectiveDate
    //
    [Fact]
    public void ValidateEffectiveDate_WhenDateIsNull_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = null;
      var expected = false;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDate(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateEffectiveDate_WhenDateIsTodayPlus8_ShouldReturnTrue()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now.AddDays(8);
      var expected = true;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDate(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateEffectiveDate_WhenDateIsTodayPlus7_ShouldReturnTrue()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now.AddDays(8);
      var expected = true;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDate(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateEffectiveDate_WhenDateIsTodayPlus6_ShouldReturnTrue()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now.AddDays(6);
      var expected = false;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDate(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateEffectiveDate_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = false;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDate(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateEffectiveDateWithRef_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = false;
      var product = new Product();

      var message = "";

      // Act
      var actual = product.ValidateEffectiveDateWithRef(effectiveDate, ref message);

      // Assert
      Assert.Equal(expected, actual);
      Assert.Equal("Date must be at least 7 days from today", message);
    }

    [Fact]
    public void ValidateEffectiveDateWithOut_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = false;
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDateWithOut(effectiveDate, out string message);

      // Assert
      Assert.Equal(expected, actual);
      Assert.Equal("Date must be at least 7 days from today", message);
    }

    [Fact]
    public void ValidateEffectiveDateWithTuple_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = (IsValid: false, Message: "Date must be at least 7 days from today");
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDateWithTuple(effectiveDate);

      // Assert
      Assert.Equal(expected, actual);
      Assert.Equal(expected.IsValid, actual.IsValid);
      Assert.Equal(expected.Message, actual.ValidationMessage);
    }

    [Fact]
    public void ValidateEffectiveDateWithObject_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = new OperationResult() { Success = false, ValidationMessage = "Date must be at least 7 days from today" };
      var product = new Product();

      // Act
      var actual = product.ValidateEffectiveDateWithObject(effectiveDate);

      // Assert
      Assert.Equal(expected.Success, actual.Success);
      Assert.Equal(expected.ValidationMessage, actual.ValidationMessage);
    }

    [Fact]
    public void ValidateEffectiveDateWithException_WhenDateIsToday_ShouldReturnFalse()
    {
      // Arrange
      DateTime? effectiveDate = DateTime.Now;
      var expected = new OperationResult() { Success = false, ValidationMessage = "Date must be at least 7 days from today" };
      var product = new Product();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => product.ValidateEffectiveDateWithException(effectiveDate));
      Assert.Equal("Date must be at least 7 days from today", ex.Message);
    }
  }
}
