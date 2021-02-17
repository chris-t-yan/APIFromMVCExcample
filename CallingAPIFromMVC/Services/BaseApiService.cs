using CallingAPIFromMVC.Interfaces;
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
    public class BaseApiService<TEntity> where TEntity : class, IEntity
    {
        private static string BASE_API_URL = "asda";
        private static string BEARER_TOKEN = "asda";
        protected TResponse SendRequest<TRequest, TResponse>(string uri, TRequest request, HttpMethod method, AuthenticationHeaderValue authentication, Dictionary<string, string> headers = null) where TResponse : class
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = authentication;
                    var payload = JsonConvert.SerializeObject(request);

                    var requestMessage = new HttpRequestMessage() { Method = method, RequestUri = new Uri(uri) };

                    if (method != HttpMethod.Get)
                    {
                        var content = new StringContent(payload, Encoding.UTF8, "application/json");
                        requestMessage.Content = content;
                    }

                    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (headers != null && headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            requestMessage.Headers.Add(header.Key, header.Value);
                        }
                    }


                    var httpResponseMessage = client.SendAsync(requestMessage).Result;
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result.Replace(@"\", string.Empty).Trim('"');

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

        public IEnumerable<TEntity> GetAll()
        {
            return SendRequest<string, IEnumerable<TEntity>>($"{BASE_API_URL}", string.Empty, HttpMethod.Get, new AuthenticationHeaderValue("Basic", BEARER_TOKEN));
        }
        public TEntity Create(TEntity entity)
        {
            return SendRequest<TEntity, TEntity>($"{BASE_API_URL}/create", entity, HttpMethod.Put, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }
        public TEntity Update(TEntity entity)
        {
            return SendRequest<TEntity, TEntity>($"{BASE_API_URL}/update", entity, HttpMethod.Post, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }
        public TEntity Delete(int id)
        {
            return SendRequest<int, TEntity>($"{BASE_API_URL}/delete", id, HttpMethod.Delete, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }


        

    }
}
