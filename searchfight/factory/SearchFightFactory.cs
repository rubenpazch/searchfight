using searchfight.logic;
using searchfight.service.interfaces;
using System;
using System.Linq;

namespace factory
{
    public class SearchFightFactory
    {
        public static ISearchManager CreateSearchManager() => CreateSearchClients();

        private static SearchManager CreateSearchClients()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("SearchFight"));

            var searchClients = loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchClient).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchClient);

            return new SearchManager(searchClients);
        }
    }
}
