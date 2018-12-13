using System;

namespace Raygun.Druid4Net
{
  public class DruidResourceExceededException : DruidClientException
  {
    public DruidResourceExceededException()
    {
    }

    public DruidResourceExceededException(string message) : base(message)
    {
    }

    public DruidResourceExceededException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
