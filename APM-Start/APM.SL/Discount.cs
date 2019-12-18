using System;
using System.Collections.Generic;

namespace APM.SL
{
  public class Discount
  {
    public int DiscountId { get; private set; }
    public string DiscountName { get; set; }

    public decimal PercentOff { get; set; }

    // ... Discount details

    public Discount FindDiscount(List<Discount> discounts, string discountName)
    {
      if (discounts is null) return null;

      var foundDiscount = discounts.Find(d => d.DiscountName == discountName);

      return foundDiscount;
    }

  }
}
