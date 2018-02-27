using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IGroupByQueryDescriptor : IAggregatableQueryDescriptor
  {
    IGroupByQueryDescriptor DataSource(Func<IGroupByQueryDescriptor, IGroupByQueryDescriptor> innerGroupByQueryDescriptor);

    IGroupByQueryDescriptor Having(IHavingSpec havingSpec);

    IGroupByQueryDescriptor Dimensions(IEnumerable<string> dimensions);

    IGroupByQueryDescriptor Limit(ILimitSpec limitSpec);
  }
}
