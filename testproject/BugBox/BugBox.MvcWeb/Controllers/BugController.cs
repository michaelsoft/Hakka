﻿using BugBox.App.Contracts.Bugs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcWebTest.Models;
using AutoMapper;

namespace BugBox.MvcWeb.Controllers
{
    public class BugController : Controller
    {
        private IBugAppService bugAppService;
        private IMapper mapper;

        public BugController(IBugAppService bugAppService, IMapper mapper)
        {
            this.bugAppService = bugAppService;
            this.mapper = mapper;
        }

        // GET: BugController
        public async Task<ActionResult> Index()
        {
            var bugDtoList = await this.LoadBugList();
            var bugVMList = this.mapper.Map<BugViewModel[]>(bugDtoList);
            return View(bugVMList);
        }

        // GET: BugController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BugController/Create
        public ActionResult Create()
        {
            var bug = new BugViewModel();

            ViewBag.SeverityList = LoadSeverityList();
            ViewBag.PriorityList = LoadPriorityList();
            ViewBag.StatusList = LoadStatusList();

            return View("Details", bug);
        }

        private async Task<List<BugDto>> LoadBugList()
        {
            return await this.bugAppService.GetListAsync();
        }

        private List<SelectListItem> LoadSeverityList()
        {
            var retVal = new List<SelectListItem>();
            retVal.Add(new SelectListItem { Text = "High", Value = "1" });
            retVal.Add(new SelectListItem { Text = "Medium", Value = "2" });
            retVal.Add(new SelectListItem { Text = "Low", Value = "3" });
            return retVal;
        }

        private List<SelectListItem> LoadPriorityList()
        {
            var retVal = new List<SelectListItem>();
            retVal.Add(new SelectListItem { Text = "High", Value = "1" });
            retVal.Add(new SelectListItem { Text = "Medium", Value = "2" });
            retVal.Add(new SelectListItem { Text = "Low", Value = "3" });
            return retVal;
        }

        private List<SelectListItem> LoadStatusList()
        {
            var retVal = new List<SelectListItem>();
            retVal.Add(new SelectListItem { Text = "New", Value = "1" });
            retVal.Add(new SelectListItem { Text = "Confirmed", Value = "2" });
            retVal.Add(new SelectListItem { Text = "Fixed", Value = "3" });
            return retVal;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CreateBugViewModel createBugViewModel)
        {
            if (!ModelState.IsValid)
                return View("Home/Error");

            try
            {
                CreateBugDto bugDto = this.mapper.Map<CreateBugDto>(createBugViewModel);
                await this.bugAppService.CreateAsync(bugDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Home/Error");
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
