using searchfight.general.config;
using searchfight.general.Exceptions;
using searchfight.general.Extensions;
using searchfight.service.interfaces;
using searchfight.service.models.google;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.service.clients
{
    public class GoogleSearchClient : ISearchClient
    {
        public string ClientName => "Google";
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _googleUrl;

        public GoogleSearchClient()
        {
            _googleUrl = ConfigManager.GoogleUri
                .Replace("{0}", ConfigManager.GoogleKey)
                .Replace("{1}", ConfigManager.GoogleCEKey);
        }

        public async Task<long> GetResultCountAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentNullException(nameof(query));

            try
            {
                using (var response = await _httpClient.GetAsync(_googleUrl.Replace("{2}",query)))
                {
                    if (response.IsSuccessStatusCode)
                        throw new SearchFightHttpException("there was a error processing your request please try again later");
                    var result = await response.Content.ReadAsStringAsync();
                    var googleResponse = result.DeserializeJson<GoogleResponse>();
                    return long.Parse(googleResponse.SearchInformation.TotalResults);
                }
            }
            catch (Exception ex)
            {

                throw new SearchFightHttpException(ex.Message);
            }
        }
    }
}
