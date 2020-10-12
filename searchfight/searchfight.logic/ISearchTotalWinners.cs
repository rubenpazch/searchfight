using searchfight.logic.models;
using System.Collections.Generic;

namespace searchfight.logic
{
    public interface ISearchTotalWinners
    {
        string GetTotalWinner(List<SearchResult> searchResults);
    }
}
