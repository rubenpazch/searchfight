﻿using System;

namespace searchfight.logic.models
{
    public class SearchResult
    {
        public string SearchClient { get; set; }
        public string Query { get; set; }
        public long TotalResults { get; set; }
    }
}
