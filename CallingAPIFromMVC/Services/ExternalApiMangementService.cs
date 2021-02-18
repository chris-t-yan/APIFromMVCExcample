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
        private const string BASE_API_URL = "baseurl here";
        private const string BEARER_TOKEN = "baseurl here";
       
        public List<Student> GetAll()
        {
            
            return SendRequest<string, List<Student>>($"{BASE_API_URL}", string.Empty, HttpMethod.Get, new AuthenticationHeaderValue("Basic", BEARER_TOKEN));
           
        }
        public Student Create(Student student)
        {
            return SendRequest<Student, Student>($"{BASE_API_URL}/create", student, HttpMethod.Put, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }
        public Student Update(Student student)
        {
            return SendRequest<Student, Student>($"{BASE_API_URL}/update", student, HttpMethod.Post, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }

        public Student Delete(int ID)
        {
            return SendRequest<int, Student>($"{BASE_API_URL}/delete", ID, HttpMethod.Delete, new AuthenticationHeaderValue("Bearer", BEARER_TOKEN));
        }
    }
}
