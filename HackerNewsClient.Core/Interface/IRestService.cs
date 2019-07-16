using System.Threading.Tasks;

namespace HackerNewsClient.Core.Interface
{
    public interface IRestService
    {
        Task<T> Get<T>(string url);
    }
}