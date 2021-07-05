namespace Raygun.Druid4Net
{
    public class ExpressionVirtualColumn
    {
        public ExpressionVirtualColumn(string name, string expression, ExpressionOutputType outputType = ExpressionOutputType.FLOAT)
        {
            Name = name;
            Expression = expression;
            OutputType = outputType;
        }

        public string Type => "expression";

        public string Name { get; }

        public string Expression { get; }

        public ExpressionOutputType OutputType { get; }
    }
}
