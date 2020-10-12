﻿using SearchFight.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Logic
{
    public interface ISearchGetWinners
    {
        
        IEnumerable<Winner> GetWinners(List<SearchResult> searchResults);
    }
}
