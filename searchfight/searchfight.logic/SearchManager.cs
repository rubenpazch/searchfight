using searchfight.general.Exceptions;
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
        private readonly ISearchReportAsync _searchReportAsync;
        private readonly ISearchGetWinners _searchGetWinners;
        private readonly ISearchTotalWinners _searchTotalWinners;
        private readonly ISearchMainResults _searchMainResults;

        public SearchManager(IEnumerable<ISearchClient> searchClients)        {
            _searchClients = searchClients;
            _stringBuilder = new StringBuilder();
            _searchReportAsync = new SearchReportAsync(searchClients);
            _searchGetWinners = new SearchGetWinners();
            _searchTotalWinners = new SearchTotalWinners();
            _searchMainResults = new SearchMainResults();
        }

        public async Task<string> GetSearchReport(List<string> querys)
        {
            if (querys == null)
                throw new ArgumentNullException(nameof(querys));

            try
            {
                var searchResults = await _searchReportAsync.GetResultsAsync(querys.Distinct());

                var winnners = _searchGetWinners.GetWinners(searchResults);
                var totalWinner = _searchTotalWinners.GetTotalWinner(searchResults);
                var mainResults = _searchMainResults.GetMainResults(searchResults);


                var clientResultsString = mainResults
                    .Select(resultsGroup =>
                        $"{resultsGroup.Key}: {string.Join(" ", resultsGroup.Select(client => $"{client.SearchClient}: {client.TotalResults}"))}")
                    .ToList();

                var winnerString = winnners.Select(client => $"{client.ClientName} winner: {client.WinnerQuery}")
                    .ToList();

                var totallWinnerString = $"Total winner: {totalWinner}";


                clientResultsString.ForEach(queryResults => _stringBuilder.AppendLine(queryResults));
                winnerString.ForEach(winners => _stringBuilder.AppendLine(winners));

                _stringBuilder.AppendLine(totallWinnerString);

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

       
    }
}
