namespace Raygun.Druid4Net
{
  public class FinalizingFieldAccessPostAggregator : FieldAccessPostAggregator
  {
    public override string Type => "finalizingFieldAccess";

    public FinalizingFieldAccessPostAggregator(string name, string fieldName) 
      : base(name, fieldName)
    {
    }
  }
}