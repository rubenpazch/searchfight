using searchfight.general.Exceptions;
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
            throw new NotImplementedException();
        }

        public Task<List<SearchResult>> GetResultsAsync(IEnumerable<string> querys)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Winner> GetWinners(List<SearchResult> searchResults)
        {
            throw new NotImplementedException();
        }
    }
}
