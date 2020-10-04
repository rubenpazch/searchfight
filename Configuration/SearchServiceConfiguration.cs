using Factory;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace Configuration
{
    public class SearchServiceConfiguration : ISearchServiceFactory
    {
        public SearchService[] GetAvailableServices()
        {
            return new SearchService[]
            {
                new BingService()
            };
        }

        public string GetOverAllWinner(SearchService[] services)
        {
            var winners = new List<string>();
            foreach (var item in services)
            {
                winners.Add(item.GetWinner());
            }

            return winners.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }
}
