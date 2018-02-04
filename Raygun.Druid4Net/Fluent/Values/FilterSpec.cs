//using System.Collections.Generic;
//using System.Linq;

//namespace Raygun.Druid4Net
//{
//  public class FilterSpec
//  {
//    public string Type { get; }

//    public IEnumerable<IFilter> fields;

//    internal string dimension;

//    internal string value;

//    internal ISearchFilterQuery query;

//    public FilterSpec(FilterSpecTypes type, IEnumerable<IFilter> fields)
//    {
//      this.type = type.ToString();
//      this.fields = fields.Where(f => f != null);
//    }

//    //public FilterSpec(FilterSpecTypes type, string dimension, string value)
//    //{
//    //  this.type = type.ToString();
//    //  this.dimension = dimension;

//    //  if (type == FilterSpecTypes.search)
//    //  {
//    //    query = new DruidQuery(value);
//    //  }
//    //  else
//    //  {
//    //    this.value = value;
//    //  }
//    //}
//  }
//}