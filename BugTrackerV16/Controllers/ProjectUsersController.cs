using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerV16.Controllers
{
    public class ProjectUsersController : Controller
    {
        // GET: ProjectUsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
