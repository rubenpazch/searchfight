using SearchFight.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Logic
{
    public class SearchMainResults : ISearchMainResults
    {
        public IEnumerable<IGrouping<string, SearchResult>> GetMainResults(List<SearchResult> searchResults)
        {
            if (searchResults == null)
                throw new ArgumentNullException(nameof(searchResults));

            var results = searchResults
                .OrderBy(result => result.SearchClient)
                .ToLookup(result => result.Query, result => result);

            return results;
        }
    }
}
