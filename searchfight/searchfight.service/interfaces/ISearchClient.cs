using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.service.interfaces
{
    public interface ISearchClient
    {
        string ClientName { get; }
        Task<long> GetResultCountAsync(string query);
    }
}
