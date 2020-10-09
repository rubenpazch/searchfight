using System;

namespace searchfight.model
{
    public class SearchResult
    {
        public string SearchClient { get; set; }
        public string Query { get; set; }
        public long TotalResults { get; set; }
    }
}
