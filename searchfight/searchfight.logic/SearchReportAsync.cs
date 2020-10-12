using SearchFight.Logic.Models;
using SearchFight.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Logic
{
    public class SearchReportAsync : ISearchReportAsync
    {
        private readonly IEnumerable<ISearchClient> _searchClients;
        public SearchReportAsync(IEnumerable<ISearchClient> searchClients)
        {
            _searchClients = searchClients;
        }
        public async Task<List<SearchResult>> GetResultsAsync(IEnumerable<string> querys)
        {
            var results = new List<SearchResult>();

            foreach (var keyword in querys)
            {
                foreach (var searchClient in _searchClients)
                {
                    results.Add(new SearchResult
                    {
                        SearchClient = searchClient.ClientName,
                        Query = keyword,
                        TotalResults = await searchClient.GetResultsCountAsync(keyword)
                    });
                }
            }

            return results;
        }
    }
}
