using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TempHire.Dal.EF;
using TempHire.Dal.EF.Services;
using TempHire.DomainModel;
using TempHire.DomainModel.Services;

namespace TempHire.MVC.Controllers
{
    public class AddressController : Controller
    {
        // If you want IRepository<Address> you get TempHire.Dal.EF.Repository<Address>
        // If you want DbContext you get TempHire.Dal.EF.TempHireDbContext

        private readonly IRepository<Address> _addressRepository;
        //
        // GET: /Address/

        public AddressController() : this(new Repository<Address>(new TempHireDbContext()))
        {
            
        }

        public AddressController(IRepository<Address> addressRepository )
        {
            _addressRepository = addressRepository;
        }

        public ActionResult Index()
        {
            return View(_addressRepository.All());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(Guid id)
        {
            return View(_addressRepository.GetById(id));
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

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
        // GET: /Address/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Address/Delete/5

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
