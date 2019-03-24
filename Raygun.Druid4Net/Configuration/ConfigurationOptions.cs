namespace Raygun.Druid4Net
{
  public class ConfigurationOptions
  {
    public ConfigurationOptions()
    {
      ApiHostName = "http://localhost";
      ApiPort = 8082;
      ApiEndpoint = "druid/v2";
    }

    public string ApiHostName { get; set; }

    public int ApiPort { get; set; }

    public string ApiEndpoint { get; set; }
    
    public IJsonSerializer JsonSerializer { get; set; }

    public ProxySettings ProxySettings { get; set; }
    
    public BasicAuthenticationCredentials BasicAuthenticationCredentials { get; set; }
  }
}