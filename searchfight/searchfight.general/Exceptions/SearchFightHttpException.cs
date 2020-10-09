using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.general.Exceptions
{
    public class SearchFightHttpException : SearchFightException
    {
        public SearchFightHttpException(string message) : base(message) { }
        public SearchFightHttpException(string message, Exception innerException) : base(message, innerException) { }

    }
}
