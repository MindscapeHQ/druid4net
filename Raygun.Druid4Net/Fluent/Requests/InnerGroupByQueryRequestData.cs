namespace Raygun.Druid4Net
{
    public class InnerGroupByQueryRequestData
    {
        public string Type => "query";

        public GroupByRequestData Query;

        public InnerGroupByQueryRequestData(GroupByRequestData query)
        {
            Query = query;
        }
    }
}