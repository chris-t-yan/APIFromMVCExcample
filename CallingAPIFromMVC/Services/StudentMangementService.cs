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
    public class StudentMangementService : BaseApiService<Student>, IStudentMangementService
    {
    }
}
