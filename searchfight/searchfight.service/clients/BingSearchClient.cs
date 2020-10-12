using Newtonsoft.Json;
using searchfight.general.config;
using searchfight.general.Exceptions;
using searchfight.service.interfaces;
using searchfight.service.models.bing;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace searchfight.service.clients
{
    public class BingSearchClient : ISearchClient
    {
        public string ClientName => "Bing Search";
        private static readonly HttpClient _httpClient;


        static BingSearchClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ConfigManager.BingUri),
                DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", ConfigManager.BingKey } }
            };
        }
        public async Task<long> GetResultCountAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException(nameof(query));
            try
            {
                using (var response = await _httpClient.GetAsync($"?q={query}"))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new SearchFightHttpException("There was an error processing your requestm please try again later");
                    var result = await response.Content.ReadAsStringAsync();
                    var bingResponse = JsonConvert.DeserializeObject<BingResponse>(result);


                    return long.Parse(bingResponse.WebPages.TotalEstimatedMatches);
                }
            }
            catch (Exception ex)
            {
                throw new SearchFightHttpException(ex.Message);
            }
        }

    }
}
