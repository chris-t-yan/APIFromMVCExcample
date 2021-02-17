using CallingAPIFromMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        public  Task<List<Student>> GetAllStudents();
        public Task<Student> GetById(int studentId);
        public Task<Student> AddUpdateStudent(Student student);
        public Task<string> Delete(int studentId);



    }
}
