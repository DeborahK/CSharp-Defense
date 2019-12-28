using APM.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace APM.SL.Test
{
  public class DiscountTest
  {
    //
    // FindDiscount
    //
    [Fact]
    public void FindDiscount_WhenListIsNull_ShouldReturnNull()
    {
      // Arrange
      List<Discount>? discounts = null;
      var discountName = "40% off";
      Discount? expected = null;
      var discount = new Discount();

      // Act
      var actual = discount.FindDiscount(discounts, discountName);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void FindDiscountWithException_WhenListIsNull_ShouldThrow()
    {
      // Arrange
      List<Discount>? discounts = null;
      var discountName = "40% off";
      var discount = new Discount();

      // Act & Assert
      var ex = Assert.Throws<ArgumentException>(() => discount.FindDiscountWithException(discounts, discountName));
      Assert.Equal("No discounts found", ex.Message);
    }

    [Fact]
    public void FindDiscountWithException_WhenNotFound_ShouldReturnNotFound()
    {
      // Arrange
      List<Discount>? discounts = new List<Discount>();
      var discountName = "40% off";
      var discount = new Discount();

      // Act & Assert
      var ex = Assert.Throws<DiscountNotFoundException>(() => discount.FindDiscountWithException(discounts, discountName));
      Assert.Equal("Discount not found", ex.Message);
    }

    [Fact]
    public void FindDiscountWithTuple_WhenListIsNull_ShouldReturnNull()
    {
      // Arrange
      List<Discount>? discounts = null;
      var discountName = "40% off";
      (Discount? Discount, string? Message) expected = (Discount: null, Message: "No discounts found");
      var discount = new Discount();

      // Act
      var actual = discount.FindDiscountWithTuple(discounts, discountName);

      // Assert
      Assert.Equal(expected, actual);
    }


  }
}
