using searchfight.logic.models;
using System.Collections.Generic;

namespace searchfight.logic
{
    public interface ISearchGetWinners
    {
        
        IEnumerable<Winner> GetWinners(List<SearchResult> searchResults);
    }
}
