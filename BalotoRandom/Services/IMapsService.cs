using BalotoRandom.Models;
using System.Threading.Tasks;

namespace BalotoRandom.Services
{
    public interface IMapsService
    {
        Task<SearchResultModel> GetTextSearch(SearchModel model);
    }
}
