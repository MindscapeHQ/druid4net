namespace Raygun.Druid4Net
{
  public interface IDruidRequest
  {
    void Build<T>(T queryDescriptor) where T :  IQueryDescriptor;

    string Body { get; }
  }
}