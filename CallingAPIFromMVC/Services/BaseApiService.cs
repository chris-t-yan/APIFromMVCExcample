using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Services
{
    public class BaseApiService
    {
        protected TResponse SendRequest<TRequest, TResponse>(string uri, TRequest sentObjToApi, HttpMethod method, AuthenticationHeaderValue authenticationToken) where TResponse : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = authenticationToken;
                    var requestContent = JsonConvert.SerializeObject(sentObjToApi);

                    var requestMessage = new HttpRequestMessage() { Method = method, RequestUri = new Uri(uri) };

                    if (method != HttpMethod.Get)
                    {
                        var content = new StringContent(requestContent, Encoding.UTF8, "application/json");
                        requestMessage.Content = content;
                    }

                    var httpResponseMessage = client.SendAsync(requestMessage).Result;
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    httpResponseMessage.EnsureSuccessStatusCode(); 
                    

                    if (string.IsNullOrEmpty(responseContent))
                    {
                        throw new Exception($"No response data.");
                    }

                    return JsonConvert.DeserializeObject<TResponse>(responseContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"URI: {uri}. Exception: {ex}");
            }
        }
    }
}
