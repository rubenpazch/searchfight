using searchfight.logic.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace searchfight.logic
{
    public interface ISearchReportAsync
    {
        Task<List<SearchResult>> GetResultsAsync(IEnumerable<string> querys);
    }
}
