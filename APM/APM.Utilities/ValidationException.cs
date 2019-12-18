using System;

namespace APM.SL
{
  [Serializable()]
  public class ValidationException : System.ArgumentException
  {
    public ValidationException() : base() { }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, string paramName) : base(message, paramName) { }

    public ValidationException(string message, Exception inner) : base(message, inner) { }

    protected ValidationException(System.Runtime.Serialization.SerializationInfo info,
                                        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

  }
}
