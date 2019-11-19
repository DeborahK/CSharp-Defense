using System;
using System.Collections.Generic;
using System.Diagnostics;

// using System.Runtime.CompilerServices;
// [assembly: InternalsVisibleTo("APM.SL.Test")]

namespace APM.SL
{

  public enum ProductCategory
  {
    GDN,
    TBX,
    GMG
  }

  public class Product
  {
    public DateTime AvailabilityDate { get; set; }
    public decimal Cost { get; set; }
    public string? Description { get; set; }
    public int ProductId { get; set; }
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }

    private static readonly Dictionary<string, ProductCategory> categories =
      new Dictionary<string, ProductCategory>{
            { "Garden", ProductCategory.GDN },
            { "Toolbox", ProductCategory.TBX },
            { "Gaming", ProductCategory.GMG }
    };

    /// <summary>
    /// Calculate the potential profit margin.
    /// </summary>
    /// <param name="costInput">Cost in dollars and cents (from user input as string)</param>
    /// <param name="priceInput">Desired percent profit margin, no decimal places (from user input as string)</param>
    /// <returns>Suggested product price</returns>
    public static decimal CalculateMargin(string costInput, string priceInput)
    {
      //if (string.IsNullOrWhiteSpace(costInput)) throw new ArgumentException("Please enter the cost");
      //if (string.IsNullOrWhiteSpace(priceInput)) throw new ArgumentException("Please enter the price");

      // decimal cost = decimal.Parse(costInput);
      // decimal price = decimal.Parse(priceInput);

      decimal cost = 0;
      var success = decimal.TryParse(costInput, out cost);
      if (!success || cost < 0) throw new ArgumentException("The cost must be a number 0 or greater");

      decimal price = 0;
      success = decimal.TryParse(priceInput, out price);
      if (!success || price <= 0) throw new ArgumentException("The price must be a number greater than 0");

      // Build an object with the validated values
      var pricingInput = new PricingInput(cost, price);

      //var x = CalculateMargin(null);

      return CalculateMargin(pricingInput);
    }

    internal static decimal CalculateMargin(PricingInput priceInput)
    {
      if (priceInput == null) throw new NullReferenceException("Pricing information cannot be null");
      //if (priceInput.Price <= 0) throw new ArgumentException("Price must be greater than 0");

      var margin = ((priceInput.Price - priceInput.Cost) / priceInput.Price) * 100M;

      return Math.Round(margin, 0);
    }
  }

  public class PricingInput
  {
    public decimal Cost { get; set; }
    public decimal Price { get; set; }

    public PricingInput(decimal cost, decimal price)
    {
      Cost = cost;
      Price = price;
    }
  }
}
