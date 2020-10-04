using Factory;
using Configuration;
using Services;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            ISearchServiceFactory factory = new SearchServiceConfiguration();
            var services = factory.GetAvailableServices();
        }
    }
}
