using System;
using System.Runtime.Serialization;

namespace Raygun.Druid4Net
{
  public class DruidClientTimeoutException : DruidClientException
  {
    public DruidClientTimeoutException()
    {
    }

    public DruidClientTimeoutException(string message) : base(message)
    {
    }

    public DruidClientTimeoutException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected DruidClientTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
