﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TempHire.Dal.EF.Services;
using TempHire.DomainModel;
using TempHire.DomainModel.Services;

namespace TempHire.MVC.Controllers
{
    public class StaffingResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //
        // GET: /Person/
        //public StaffingResourceController() : this(new UnitOfWork())
        //{
            
        //}

        public StaffingResourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.StaffingResources.All().Include(e=>e.Addresses));
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(Guid id)
        {
            return View(_unitOfWork.StaffingResources.GetById(id));
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            // if(ModelState.IsValid)
            try
            {
                var person = _unitOfWork.StaffingResources.GetById(id);
                if (person == null)
                {
                    return HttpNotFound();
                }

                if (TryUpdateModel<StaffingResource>(person, 
                    //new string[]{"FirstName", "LastName", "MiddleName"}, 
                    collection))
                {
                    _unitOfWork.Commit();
                }

                //person

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Person/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
