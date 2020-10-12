using searchfight.logic.models;
using searchfight.service.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace searchfight.logic
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
                        TotalResults = await searchClient.GetResultCountAsync(keyword)
                    });
                }
            }

            return results;
        }
    }
}
