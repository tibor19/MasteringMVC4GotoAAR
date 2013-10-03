using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TempHire.Dal.EF;
using TempHire.DomainModel;
using TempHire.MVC.Models.TempHire;

namespace TempHire.MVC.Controllers.Api
{
    public class AddressTypeController : ApiController
    {
        private TempHireDbContext db = new TempHireDbContext();

        // GET api/AddressType
        public IEnumerable<AddressType> GetAddressTypes()
        {
            return db.AddressTypes.AsEnumerable();
        }

        // GET api/AddressType/5
        public AddressType GetAddressType(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            if (addresstype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return addresstype;
        }

        // PUT api/AddressType/5
        public HttpResponseMessage PutAddressType(Guid id, AddressType addresstype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != addresstype.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(addresstype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/AddressType
        public HttpResponseMessage PostAddressType(AddressType addresstype)
        {
            if (ModelState.IsValid)
            {
                db.AddressTypes.Add(addresstype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, addresstype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = addresstype.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/AddressType/5
        public HttpResponseMessage DeleteAddressType(Guid id)
        {
            AddressType addresstype = db.AddressTypes.Find(id);
            if (addresstype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.AddressTypes.Remove(addresstype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, addresstype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}