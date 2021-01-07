using System.Collections.Generic;

namespace Raygun.Druid4Net
{
    public class VirtualColumnQueryRequestData : QueryRequestData
    {
        public IEnumerable<ExpressionVirtualColumn> VirtualColumns { get; internal set; }
    }
}
