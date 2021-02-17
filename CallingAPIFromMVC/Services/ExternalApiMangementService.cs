using CallingAPIFromMVC.Interfaces;
using CallingAPIFromMVC.Models;
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
            BASE_API_URL = "https://localhost:44323/api/MockExternalRepo";
        }
        public List<Student> GetAll()
        {
            
            return SendRequest<string, List<Student>>($"{BASE_API_URL}", null, HttpMethod.Get, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }
        public Student Create(Student o)
        {
            return SendRequest<Student, Student>($"{BASE_API_URL}/create", o, HttpMethod.Put, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }
        public Student Update(Student o)
        {
            return SendRequest<Student, Student>($"{BASE_API_URL}/update", o, HttpMethod.Post, new AuthenticationHeaderValue("Bearer", "SomeToken"));
        }

        public Student Delete(int ID)
        {
            return SendRequest<int, Student>($"{BASE_API_URL}/delete", ID, HttpMethod.Delete, new AuthenticationHeaderValue("Bearer", "SomeToken"));

        }
    }
}
