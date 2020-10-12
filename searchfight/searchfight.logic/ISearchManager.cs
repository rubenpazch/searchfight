using searchfight.logic.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.logic
{
    public interface ISearchManager
    {
        Task<string> GetSearchReport(List<string> querys);
        Task<List<SearchResult>> GetResultsAsync(IEnumerable<String> querys);
        IEnumerable<Winner> GetWinners(List<SearchResult> searchResults);
        string GetTotalWinner(List<SearchResult> searchResults);
        IEnumerable<IGrouping<string, SearchResult>> GetMainResults(List<SearchResult> searchResults);
    }
}
