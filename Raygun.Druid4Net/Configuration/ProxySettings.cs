namespace Raygun.Druid4Net
{
  public class ProxySettings
  {
    public string Address  { get; set; }
    
    public bool BypassOnLocal  { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }

    public override string ToString() => $"{Username}:{Password}";
  }
}