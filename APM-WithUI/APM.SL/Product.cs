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
      decimal cost = 0;

      // Original
      //decimal cost = decimal.Parse(costInput);
      //decimal price = decimal.Parse(priceInput);

      // Try 1:
      decimal cost = 0;
      decimal.TryParse(costInput, out cost);

      decimal price = 0;
      decimal.TryParse(priceInput, out price);

      var margin = ((price - cost) / price) * 100M;

      return margin;
    }
  }

}
