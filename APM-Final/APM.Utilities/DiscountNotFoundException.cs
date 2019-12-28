using System;
using System.Collections.Generic;
using System.Text;

namespace APM.Utilities
{
  [Serializable()]
  public class DiscountNotFoundException : System.Exception
  {
    public DiscountNotFoundException() : base() { }

    public DiscountNotFoundException(string message) : base(message) { }

    public DiscountNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected DiscountNotFoundException(System.Runtime.Serialization.SerializationInfo info,
                                        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }
}
