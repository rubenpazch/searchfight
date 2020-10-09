using System;

namespace Models
{
    public interface ISearchFight
    {
        TermSearchResult[] GetTermSearchResults(string[] terms);
        bool TryValidateTerms(string[] terms, string[] validateErrors);
    }
}
