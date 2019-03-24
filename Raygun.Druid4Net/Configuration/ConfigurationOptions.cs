using System;

namespace Raygun.Druid4Net
{
  public class ConfigurationOptions
  {
    public ConfigurationOptions()
    {
      QueryApiBaseAddress = new Uri("http://localhost:8082");
      QueryApiEndpoint = "druid/v2";
    }

    public Uri QueryApiBaseAddress { get; set; }
    
    public string QueryApiEndpoint { get; set; }

    public IJsonSerializer JsonSerializer { get; set; }

    public ProxySettings ProxySettings { get; set; }
    
    public BasicAuthenticationCredentials BasicAuthenticationCredentials { get; set; }
  }
}