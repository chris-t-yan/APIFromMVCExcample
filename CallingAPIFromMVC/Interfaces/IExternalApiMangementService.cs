using CallingAPIFromMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Interfaces
{
    public interface IExternalApiMangementService
    {
        List<Student> GetAll();
        Student Create(Student student);
        Student Update(Student student);
        Student Delete(int ID);
    }
}
