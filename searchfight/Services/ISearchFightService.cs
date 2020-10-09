using Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Services
{
    public interface ISearchFightService
    {
        string getOverAllWinnerTerm(IEnumerable<ModelTermSearchResult> results);
        ModelTermSearchResult[] getWinnersPerSearchEngine(IEnumerable<ModelTermSearchResult> results);
    }
}
