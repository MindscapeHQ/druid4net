using System;
using System.Collections.Generic;

namespace Raygun.Druid4Net
{
  public class SearchResult : List<SearchResultList>
  {
    
  }
  
  public class SearchResultList
  {
    public DateTime Timestamp { get; set; }

    public List<SearchResultItem> Result { get; set; }
  }
  
  public class SearchResultItem
  {
    public string Dimension { get; set; }
    
    public string Value { get; set; }
    
    public int Count { get; set; }
  }
}