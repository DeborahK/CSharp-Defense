using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace APM.SL
{

  public class Product
  {

    /// <summary>
    /// Calculate the potential profit margin.
    /// </summary>
    /// <param name="costInput">Cost in dollars and cents (from user input as string)</param>
    /// <param name="priceInput">Desired percent profit margin, no decimal places (from user input as string)</param>
    /// <returns>Resulting profit margin</returns>
    public decimal CalculateMargin(string costInput, string priceInput)
    {
      decimal cost = decimal.Parse(costInput);
      decimal price = decimal.Parse(priceInput);

      var margin = ((price - cost) / price) * 100M;

      return Math.Round(margin);
    }
  }

}
