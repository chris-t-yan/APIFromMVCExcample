using CallingAPIFromMVC.Interfaces;
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
        private readonly IExternalApiMangementService _externalApiMangementService;

        HttpClientHandler _clientHandler = new HttpClientHandler();
        Student _oStudent = new Student();
        List<Student> _oStudents = new List<Student>();

        public StudentsController(IExternalApiMangementService externalApiMangementService)
        {
            _externalApiMangementService = externalApiMangementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region new methods
        public List<Student> GetAll() => 
            _externalApiMangementService.GetAll();
        public  Student GetStudentByID(int studentId) => _externalApiMangementService.GetAll().FirstOrDefault(x => x.StudentId == studentId);
        [HttpPost]
        public  Student Create(Student student) => _externalApiMangementService.Create(student);
        [HttpPut]
        public Student Update(Student student) => _externalApiMangementService.Update(student);
        public Student DeleteUser(int studentID) => _externalApiMangementService.Delete(studentID);
        #endregion

        #region old methods
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
        #endregion
    }   

}
