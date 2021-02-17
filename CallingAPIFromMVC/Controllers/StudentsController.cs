using CallingAPIFromMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Controllers
{
    public class StudentsController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();
        Student _oStudent = new Student();
        List<Student> _oStudents = new List<Student>();

        public StudentsController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
            _oStudents = new List<Student>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("url od kade sto treba da se povika"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oStudents = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return _oStudents;
        }
        [HttpGet]
        public async Task<Student> GetById(int studentId)
        {
            _oStudent = new Student();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("url od kade sto treba da se povika"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oStudent = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return _oStudent;
        }
        [HttpPost]
        public async Task<Student> AddUpdateStudent(Student student)
        {
            _oStudent = new Student();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("url od kade sto treba da se povika", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oStudent = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return _oStudent;
        }

        [HttpDelete]
        public async Task<string> Delete(int studentId)
        {
            string message = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("url od kade sto treba da se povika"))
                {
                    message = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return message;
        }

    }   

}
