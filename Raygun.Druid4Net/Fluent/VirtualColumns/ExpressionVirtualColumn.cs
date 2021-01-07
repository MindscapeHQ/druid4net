namespace Raygun.Druid4Net
{
    public class ExpressionVirtualColumn
    {
        public ExpressionVirtualColumn(string name, string expression, ExpressionOutputType outputType = ExpressionOutputType.FLOAT)
        {
            this.Name = name;
            this.Expression = expression;
            this.OutputType = outputType;
        }
        
        public string Type => "expression";

        public string Name { get; internal set; }
        
        public string Expression { get; internal set; }
        
        public ExpressionOutputType OutputType { get; internal set; }
    }
}
