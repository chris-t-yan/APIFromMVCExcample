using CallingAPIFromMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Services
{
    public class ExternalApiMangementService : BaseApiService, IExternalApiMangementService
    {
        private static string BASE_API_URL;
        public ExternalApiMangementService()
        {
            BASE_API_URL = "Some URL";
        }
        public object GetAll()
        {
            return SendRequest<string, object>($"{BASE_API_URL}/Get", null, HttpMethod.Get, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }
        public object Create(object o)
        {
            return SendRequest<object, object>($"{BASE_API_URL}/create", o, HttpMethod.Put, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }
        public object Update(object o)
        {
            return SendRequest<object, object>($"{BASE_API_URL}/update", o, HttpMethod.Post, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }
    }
}
