using System.Threading.Tasks;

namespace Raygun.Druid4Net
{
  public interface IRequester
  {
    Task<IQueryResponse<TResponse>> PostAsync<TResponse, TRequest>(string endpoint, IDruidRequest<TRequest> request)
      where TResponse : class
      where TRequest : QueryRequestData;
  }
}