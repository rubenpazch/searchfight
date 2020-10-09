using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ModelTermSearchResult
    {
        public long Count { get; set; }
        public string SearchEngineName { get; set; }
        public string Term { get; set; }
    }
}
