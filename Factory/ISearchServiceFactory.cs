using Services;

namespace Factory
{
    public interface ISearchServiceFactory
    {
        SearchService[] GetAvailableServices();
        string GetOverAllWinner(SearchService[] services);
    }
}
