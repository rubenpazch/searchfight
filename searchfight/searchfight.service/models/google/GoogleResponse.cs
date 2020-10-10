using searchfight.service.models.google;
using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.service.models.google
{
    public class GoogleResponse
    {
        public string Kind { get; set; }
        public SearchInformation SearchInformation { get; set; }
    }
}
