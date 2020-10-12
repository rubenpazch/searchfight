using searchfight.logic.models;
using System.Collections.Generic;
using System.Linq;

namespace searchfight.logic
{
    public interface ISearchMainResults
    {
        IEnumerable<IGrouping<string, SearchResult>> GetMainResults(List<SearchResult> searchResults);
    }
}
