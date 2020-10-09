using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISearchResultModelMapper
    {
        IEnumerable<ModelTermSearchResult> toDataModel(IEnumerable<TermSearchResult> results);
        IEnumerable<ModelTermSearchResult> ToViewModel(IEnumerable<ModelTermSearchResult> results);
    }
}
