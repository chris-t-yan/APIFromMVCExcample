using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallingAPIFromMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallingAPIFromMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockExternalRepoController : ControllerBase
    {
        // GET: api/<MockExternalRepoController>
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
             List <Student> students = new List<Student>()
            {
                new Student{ StudentId=1, Name="name1", Roll="student" },
                new Student{ StudentId=2, Name="name2", Roll="student" },
                new Student{ StudentId=3, Name="name3", Roll="student" },
                new Student{ StudentId=4, Name="name4", Roll="student" },
                new Student{ StudentId=5, Name="name5", Roll="student" },
                new Student{ StudentId=6, Name="name6", Roll="student" },
                new Student{ StudentId=7, Name="name7", Roll="student" },
                new Student{ StudentId=8, Name="name8", Roll="student" },
                new Student{ StudentId=9, Name="name9", Roll="student" },
            };
            return students;

        }

        // GET api/<MockExternalRepoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MockExternalRepoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MockExternalRepoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MockExternalRepoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
