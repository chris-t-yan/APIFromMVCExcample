using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallingAPIFromMVC.Interfaces;
using CallingAPIFromMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingAPIFromMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IStudentMangementService _externalApiMangementService;
        public UsersController(IStudentMangementService externalApiMangementService)
        {
            _externalApiMangementService = externalApiMangementService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(_externalApiMangementService.GetAll());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_externalApiMangementService.GetAll().FirstOrDefault(x=> x.StudentId == id));
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _externalApiMangementService.Create((Student)collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_externalApiMangementService.GetAll().FirstOrDefault(x => x.StudentId == id));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _externalApiMangementService.Update((Student)collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            _externalApiMangementService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _externalApiMangementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
