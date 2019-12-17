using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace APM.SL
{
  public class Product
  {
    // Value Types
    public DateTime? EffectiveDate { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }

    // Reference Types
    public string Category { get; set; } = "";

    public List<Discount> Discounts { get; set; }

    public Discount ProductDiscount { get; set; }

    public string ProductName { get; set; } = "";

    public string Reason { get; set; } = "";



    /// <summary>
    /// Calculate the potential profit margin.
    /// </summary>
    /// <param name="costInput">Cost in dollars and cents (from user input as string)</param>
    /// <param name="priceInput">Suggested price in dollars and cents (from user input as string)</param>
    /// <returns>Resulting profit margin</returns>
    public decimal CalculateMargin(string costInput, string priceInput)
    {
      decimal cost = decimal.Parse(costInput);
      decimal price = decimal.Parse(priceInput);

      var margin = ((price - cost) / price) * 100M;

      return margin;
    }



    /// <summary>
    /// Calculates the total amount of the discount
    /// </summary>
    /// <returns></returns>
    public decimal CalculateTotalDiscount(decimal price, Discount discount)
    {
      if (price <= 0) throw new ArgumentException("Please enter the price");

      if (discount is null) throw new ArgumentException("Please specify a discount");

      var discountAmount = price * (discount.PercentOff / 100);

      return discountAmount;
    }

    /// <summary>
    /// Saves pricing details.
    /// </summary>
    /// <returns></returns>
    public bool SavePrice(int productId, string cost, string price,
                          string category, string reason,
                          DateTime effectiveDate)
    {
      // Generates a warning if nullable is set to "warnings"
      // string name = null;
      // Console.WriteLine(name.Length);

      // To turn off unused parameter warnings
      Utility.LogToFile(new string[] { "Price Saved:", productId.ToString(), cost, price, category, reason, effectiveDate.ToString() });

      // Validate arguments
      // Calls a method in the data layer to save the data...

      return true;
    }

    /// <summary>
    /// Validates the effective data according to two rules:
    /// - Effective date is required
    /// - Effective date is one week (or more) beyond the current date
    /// </summary>
    /// <param name="effectiveDate"></param>
    /// <returns></returns>
    public bool ValidateEffectiveDate(DateTime? effectiveDate)
    {
      if (!effectiveDate.HasValue) return false;

      if (effectiveDate.Value < DateTime.Now.AddDays(7)) return false;

      return true;
    }

    public bool ValidateEffectiveDateWithRef(DateTime? effectiveDate, ref string validationMessage)
    {
      if (!effectiveDate.HasValue) return false;

      if (effectiveDate.Value < DateTime.Now.AddDays(7))
      {
        validationMessage = "Date must be at least 7 days from today";
        return false;
      }

      return true;
    }

    public bool ValidateEffectiveDateWithOut(DateTime? effectiveDate, out string validationMessage)
    {
      validationMessage = "";
      if (!effectiveDate.HasValue) return false;

      if (effectiveDate.Value < DateTime.Now.AddDays(7))
      {
        validationMessage = "Date must be at least 7 days from today";
        return false;
      }

      return true;
    }

    public (bool IsValid, string ValidationMessage) ValidateEffectiveDateWithTuple(DateTime? effectiveDate)
    {
      if (!effectiveDate.HasValue) return (IsValid: false, ValidationMessage: "Date has no value");

      if (effectiveDate.Value < DateTime.Now.AddDays(7)) return (false, "Date must be at least 7 days from today");

      return (IsValid: true, ValidationMessage: "");
    }

    public OperationResult ValidateEffectiveDateWithObject(DateTime? effectiveDate)
    {
      if (!effectiveDate.HasValue) return new OperationResult()
      { Success = false, ValidationMessage = "Date has no value" };

      if (effectiveDate.Value < DateTime.Now.AddDays(7)) return new OperationResult()
      { Success = false, ValidationMessage = "Date must be at least 7 days from today" };

      return new OperationResult() { Success = true };
    }

    public bool ValidateEffectiveDateWithException(DateTime? effectiveDate)
    {
      if (!effectiveDate.HasValue) throw new ArgumentException("Please enter the effective date");

      if (effectiveDate.Value < DateTime.Now.AddDays(7)) throw new ArgumentException("Date must be at least 7 days from today");

      return true;
    }
  }
}
