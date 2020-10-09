using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.general.Exceptions
{
    public class SearchFightException : Exception
    {
        public SearchFightException(string message) : base(message) { }
        public SearchFightException(string message, Exception innerException) : base(message, innerException) { }
    }
}
