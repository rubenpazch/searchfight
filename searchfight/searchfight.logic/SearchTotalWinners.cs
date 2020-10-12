using searchfight.general.Extensions;
using searchfight.logic.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace searchfight.logic
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
