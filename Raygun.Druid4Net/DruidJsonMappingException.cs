using System;

namespace Raygun.Druid4Net
{
  public class DruidJsonMappingException : DruidClientException
  {
    public DruidJsonMappingException()
    {
    }

    public DruidJsonMappingException(string message) : base(message)
    {
    }

    public DruidJsonMappingException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}
