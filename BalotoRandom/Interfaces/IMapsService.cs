using BalotoRandom.Models;
using System.Threading.Tasks;

namespace BalotoRandom.Interfaces
{
    public interface IMapsService
    {
        Task<SearchResultModel> GetTextSearch(SearchModel model);
    }
}
