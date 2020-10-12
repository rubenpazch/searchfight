using searchfight.general.Exceptions;
using searchfight.general.Extensions;
using searchfight.logic.models;
using searchfight.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.logic
{
    public class SearchManager : ISearchManager
    {
        private readonly IEnumerable<ISearchClient> _searchClients;
        private readonly StringBuilder _stringBuilder;

        public SearchManager(IEnumerable<ISearchClient> searchClients)
        {
            _searchClients = searchClients;
            _stringBuilder = new StringBuilder();
        }
        public IEnumerable<IGrouping<string, SearchResult>> GetMainResults(List<SearchResult> searchResults)
        {
            if (searchResults == null)
                   throw new ArgumentNullException(nameof(searchResults));
            var results = searchResults
                .OrderBy(result => result.SearchClient)
                .ToLookup(result => result.Query, result => result);
            return results;
        }

        public  async Task<List<SearchResult>> GetResultsAsync(IEnumerable<string> querys)
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

        public async Task<string> GetSearchReport(List<string> querys)
        {
            if (querys == null)
                throw new ArgumentNullException(nameof(querys));
            try
            {
                var searchResults = await GetResultsAsync(querys.Distinct());
                var winners = GetWinners(searchResults);
                var totalWinner = GetTotalWinner(searchResults);
                var mainResults = GetMainResults(searchResults);

                var clientResultsString = mainResults
                    .Select(resultGroup => $"{resultGroup.Key}: {string.Join(" ", resultGroup.Select(client=> $"{client.SearchClient}: {client.TotalResults}"))}")
                    .ToList();

                var winnerString = winners.Select(client=> $"{client.ClientName} winner: {client.WinnerQuery}")
                    .ToList();

                var totalWinnerString = $"Total Winner: {totalWinner}";

                clientResultsString.ForEach(queryResults => _stringBuilder.AppendLine(queryResults));

                winnerString.ForEach(winners => _stringBuilder.AppendLine(winners));

                return _stringBuilder.ToString();
            }
            catch (SearchFightLogicException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new SearchFightLogicException("Error processing results,please try again later", e);
            }
        }

        public string GetTotalWinner(List<SearchResult> searchResults)
        {
            if (searchResults == null)
                throw new ArgumentNullException(nameof(searchResults));
            var totalWinner = searchResults
                .OrderBy(result => result.SearchClient)
                .GroupBy(result => result.Query, result => result,
                    (query, result) => new { Query = query, Total = result.Sum(r => r.TotalResults) })
                .MaxValue(r=> r.Total).Query;
            return totalWinner;
        }

        public IEnumerable<Winner> GetWinners(List<SearchResult> searchResults)
        {
            if (searchResults == null)
                throw new ArgumentNullException(nameof(searchResults));
            var winners = searchResults
                .OrderBy(result => result.SearchClient)
                .GroupBy(result => result.SearchClient, result => result,
                    (client, result) => new Winner
                    {
                        ClientName = client,
                        WinnerQuery = result.MaxValue(r => r.TotalResults).Query
                    });

            return winners;
        }
    }
}
