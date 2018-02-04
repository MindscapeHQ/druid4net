using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IQueryResponse<T>
  {
    T Data { get; }
    QueryRequestData RequestData { get; }
  }
}
