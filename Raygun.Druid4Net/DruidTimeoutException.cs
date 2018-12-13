using System;

namespace Raygun.Druid4Net
{
  public class DruidTimeoutException : DruidClientException
  {
    public DruidTimeoutException()
    {
    }

    public DruidTimeoutException(string message) : base(message)
    {
    }

    public DruidTimeoutException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
