using searchfight.logic;
using searchfight.service.interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace searchfight.factory
{
    public class SearchFightFactory
    {
        public static ISearchManager CreateSearchManager() => CreateSearchClients();

        private static SearchManager CreateSearchClients()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Assembly[] assems = currentDomain.GetAssemblies();

            var searchClients = assems
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchClient).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchClient);

            return new SearchManager(searchClients);
        }
    }
}
