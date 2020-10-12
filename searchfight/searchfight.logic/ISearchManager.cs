using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using searchfight.logic.models;

namespace searchFight.logic
{
    public interface ISearchManager
    {
        Task<string> GetSearchReport(List<string> querys);
    }
}
