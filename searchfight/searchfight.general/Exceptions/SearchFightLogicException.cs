using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.general.Exceptions
{
    public class SearchFightLogicException :  SearchFightException
    {
        public SearchFightLogicException(string message) : base(message) { }
        public SearchFightLogicException(string message, Exception innerException) : base(message, innerException) { }
    }
}
