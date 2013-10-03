using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TempHire.Dal.EF;
using TempHire.DomainModel;
using TempHire.MVC.Models;

namespace TempHire.MVC.Controllers
{
    public class AddressTypeController : Controller
    {
        private TempHireDbContext db = new TempHireDbContext();

        //
        // GET: /AddressType/

        public ActionResult Index()
        {
            return View(db.AddressTypes.ToList());
        }

        //
        // GET: /AddressType/Details/5

        public ActionResult Details(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            if (addresstype == null)
            {
                return HttpNotFound();
            }
            return View(addresstype);
        }

        //
        // GET: /AddressType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AddressType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressType addresstype)
        {
            if (ModelState.IsValid)
            {
                addresstype.Id = Guid.NewGuid();
                db.AddressTypes.Add(addresstype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addresstype);
        }

        //
        // GET: /AddressType/Edit/5

        public ActionResult Edit(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            if (addresstype == null)
            {
                return HttpNotFound();
            }
            return View(addresstype);
        }

        //
        // POST: /AddressType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressType addresstype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addresstype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addresstype);
        }

        //
        // GET: /AddressType/Delete/5

        public ActionResult Delete(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            if (addresstype == null)
            {
                return HttpNotFound();
            }
            return View(addresstype);
        }

        //
        // POST: /AddressType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            db.AddressTypes.Remove(addresstype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}