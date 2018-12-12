using System;

namespace Raygun.Druid4Net
{
  public class DruidClientException : Exception
  {
    public DruidClientException()
    {
    }

    public DruidClientException(string message) : base(message)
    {
    }

    public DruidClientException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
