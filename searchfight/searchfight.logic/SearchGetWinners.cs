using SearchFight.Common.Exceptions;
using SearchFight.Common.Extensions;
using SearchFight.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Logic
{
    public class SearchGetWinners : ISearchGetWinners
    {
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
