﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Net;
using ServiceLayer;
using ServiceLayer.Interface;
using CommonClasses;
using BusinessObjects;
using LMS.Models.DevelopmentTools;

namespace LMS.Controllers.DevelopmentTools
{
    public class DevelopmentToolsController : Controller
    {
        private ILibrarySvc service;

        public DevelopmentToolsController()
            : this(new LibrarySvc())
        {
        }

        public DevelopmentToolsController(ILibrarySvc service)
        {            
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Library()
        {
            LibraryComponentModel md = new LibraryComponentModel();
            md.ComponentName = "Company Type";
            ViewBag.Title = "Loans Management System";
            return View(md);
        }
        
        [HttpGet]
        public ActionResult FetchLibraryComponent()
        {
            return Json(this.service.getLibraryComponent("borrower_type"),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FetchLibraryUpdateCompent()
        {
            return Json(this.service.getLIbraryUpdateComponent("borrower_type" + "UpdCom"),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddComponent(string compData,int opCode)
        {
            compData = Guid.NewGuid().ToString() + "|" + compData;
            int resp = this.service.updLibraryComponent("borrower_type", opCode, compData);
            return Content(resp == 1 ? "1" : resp.ToString());
        }

        [HttpPost]        
        public ActionResult UpdateComponent(string compData, int opCode)
        {
            int resp = this.service.updLibraryComponent("borrower_type", opCode, compData);
            return Content(resp == 1 ? "1" : resp.ToString());
        }

        [HttpPost]
        public ActionResult DeleteComponent(string compData, int opCode)
        {
            int resp = this.service.updLibraryComponent("borrower_type", opCode, compData);
            return Content(resp == 1 ? "1" : resp.ToString());
        }
    }
}