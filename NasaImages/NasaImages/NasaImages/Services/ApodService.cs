using NasaImages.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NasaImages.Services
{
    public class ApodService : IApodService
    {
        private const string ApiKey = "NNKOjkoul8n1CH18TWA9gwngW1s1SmjESPjNoUFo";
        // private const string ApiKey = "NNKOjkoul8n1CH18TWA9gwngW1s1SmjESPjNoUFocffg";
        private string BaseUrl = string.Format("https://api.nasa.gov/planetary/apod?api_key={0}", ApiKey);


        public async Task<TResult> GetAposAsync<TResult>()
        {
            try
            {

                using (var httpclient = new HttpClient())
                {
                    var response = await httpclient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TResult>(json);
                    }

                }
            }
            catch (Exception ex)
            {
                return default(TResult);
            }

            return default(TResult);
        }

    }
}
