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
        Student Create(Student o);
        Student Update(Student o);
        Student Delete(int ID);
    }
}
