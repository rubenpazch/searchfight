using System.Collections.Generic;
using System.Threading.Tasks;

namespace searchfight.logic
{
    public interface ISearchManager
    {
        Task<string> GetSearchReport(List<string> querys);
    }
}
