using CallingAPIFromMVC.Interfaces;
using CallingAPIFromMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Services
{
    public class TeacherManagementService : BaseApiService<Teacher> , ITeacherManagementService
    {
    }
}
