using searchfight.logic.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchfight.logic
{
    public class SearchManager : ISearchManager
    {
        private readonly IEnumerable<IS>
        public IEnumerable<IGrouping<string, SearchResult>> GetMainResults(List<SearchResult> searchResults)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchResult>> GetResultsAsync(IEnumerable<string> querys)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSearchReport(List<string> querys)
        {
            throw new NotImplementedException();
        }

        public string GetTotalWinner(List<SearchResult> searchResults)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Winner> GetWinners(List<SearchResult> searchResults)
        {
            throw new NotImplementedException();
        }
    }
}
