using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_pdg13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_pdg13.Controllers
{
    public class HomeController : Controller
    {
        private MovieDatabaseContext daContext { get; set; }

        public HomeController(MovieDatabaseContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = daContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = daContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.Responses.Single(x => x.ApplicationID == applicationid);

            return View("Movies", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = daContext.Responses.Single(x => x.ApplicationID == applicationid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.Responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
