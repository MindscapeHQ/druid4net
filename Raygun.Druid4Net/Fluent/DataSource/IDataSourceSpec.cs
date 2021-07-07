namespace Raygun.Druid4Net
{
  public interface IDataSourceSpec
  {
    string Type { get; }
  }
  
  public interface ILeftJoinDataSource
  {
  }
  
  public interface IRightJoinDataSource
  {
  }
}