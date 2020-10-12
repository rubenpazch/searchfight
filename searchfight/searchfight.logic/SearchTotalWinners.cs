using SearchFight.Common.Extensions;
using SearchFight.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Logic
{
    public class SearchTotalWinners : ISearchTotalWinners
    {
        public string GetTotalWinner(List<SearchResult> searchResults)
        {
            if (searchResults == null)
                throw new ArgumentNullException(nameof(searchResults));

            var totalWinner = searchResults
                .OrderBy(result => result.SearchClient)
                .GroupBy(result => result.Query, result => result,
                    (query, result) => new { Query = query, Total = result.Sum(r => r.TotalResults) })
                .MaxValue(r => r.Total).Query;

            return totalWinner;
        }
    }
}
