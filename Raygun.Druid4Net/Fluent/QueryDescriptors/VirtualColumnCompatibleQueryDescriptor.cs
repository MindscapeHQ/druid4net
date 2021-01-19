using System.Collections.Generic;

namespace Raygun.Druid4Net
{
    public abstract class VirtualColumnCompatibleQueryDescriptor : QueryDescriptor
    {
        internal IEnumerable<ExpressionVirtualColumn> VirtualColumnsValue;
        
        protected void SetVirtualColumns(IEnumerable<ExpressionVirtualColumn> virtualColumns)
        {
            VirtualColumnsValue = virtualColumns;
        }
    }
}
