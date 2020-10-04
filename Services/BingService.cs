using Engines;

namespace Services
{
    public class BingService : SearchService
    {
        public override string Name => "Bing";

        public override ISearchEngine CreateEngine()
        {
            return new BingEngine();
        }
    }
}
