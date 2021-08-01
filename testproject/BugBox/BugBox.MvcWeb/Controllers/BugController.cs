using BugBox.App.Contracts.Bugs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugBox.MvcWeb.Controllers
{
    public class BugController : Controller
    {
        private IBugAppService bugAppService;

        public BugController(IBugAppService bugAppService)
        {
            this.bugAppService = bugAppService;
        }

        // GET: BugController
        public ActionResult Index()
        {
            var bugList = new List<BugDto>();
            return View(bugList);
        }

        // GET: BugController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BugController/Create
        public ActionResult Create()
        {
            var bug = new BugDto();

            List<SelectListItem> severityList = new List<SelectListItem>();
            severityList.Add(new SelectListItem { Text = "High", Value = "1" });
            severityList.Add(new SelectListItem { Text = "Medium", Value = "2" });
            severityList.Add(new SelectListItem { Text = "Low", Value = "3" });
            ViewBag.SeverityList = severityList;

            return View("Details", bug);
        }

        // POST: BugController/Create
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

        // GET: BugController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BugController/Edit/5
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

        // GET: BugController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BugController/Delete/5
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
