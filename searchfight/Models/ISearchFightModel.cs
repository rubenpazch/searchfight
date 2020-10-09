using System;

namespace Models
{
    public interface ISearchFightModel
    {
        ModelTermSearchResult[] GetTermSearchResults(string[] terms);
        bool TryValidateTerms(string[] terms, string[] validateErrors);
    }
}
