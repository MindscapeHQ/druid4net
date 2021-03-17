using System.Collections.Generic;

namespace Raygun.Druid4Net.ToInclude
{
    public class ToIncludeListSpec : IToIncludeSpec
    {
        public string Type => "list";
        
        public IEnumerable<string> Columns { get; }

        public ToIncludeListSpec(params string[] columnNames)
        {
            Columns = columnNames;
        }
    }
}
