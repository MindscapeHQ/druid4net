namespace Raygun.Druid4Net
{
  public class JoinDataSource : IDataSourceSpec, ILeftJoinDataSource
  {
    public string Type => "join";

    public ILeftJoinDataSource Left { get; }
    
    public IRightJoinDataSource Right { get; }
    
    public string RightPrefix { get; }
    
    public string Condition { get; }
    
    public JoinType JoinType { get; }

    public JoinDataSource(ILeftJoinDataSource left, IRightJoinDataSource right, string rightPrefix, string condition, JoinType joinType)
    {
      Left = left;
      Right = right;
      RightPrefix = rightPrefix;
      Condition = condition;
      JoinType = joinType;
    }
  }
}