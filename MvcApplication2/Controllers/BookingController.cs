using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class BookingController : ApiController
    {
        private readonly BookingContext _db = new BookingContext();

        // GET api/Booking
        public IEnumerable<TblCustomerBooking> GetTblCustomerBookings()
        {
            //_db.Configuration.ProxyCreationEnabled = false;
            var res = _db.TblCustomerBookings.AsEnumerable();
            return res;
        }

        // GET api/Booking/5
        public TblCustomerBooking GetTblCustomerBooking(int id)
        {
            TblCustomerBooking tblcustomerbooking = _db.TblCustomerBookings.Find(id);
            if (tblcustomerbooking == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tblcustomerbooking;
        }

        // PUT api/Booking/5
        public HttpResponseMessage PutTblCustomerBooking(int id, TblCustomerBooking tblcustomerbooking)
        {
            if (ModelState.IsValid && id == tblcustomerbooking.customer_id)
            {
                _db.Entry(tblcustomerbooking).State = EntityState.Modified;

                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, tblcustomerbooking);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Booking
        public HttpResponseMessage PostTblCustomerBooking(TblCustomerBooking tblcustomerbooking)
        {
            if (ModelState.IsValid)
            {
                _db.TblCustomerBookings.Add(tblcustomerbooking);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tblcustomerbooking);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tblcustomerbooking.customer_id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Booking/5
        public HttpResponseMessage DeleteTblCustomerBooking(int id)
        {
            TblCustomerBooking tblcustomerbooking = _db.TblCustomerBookings.Find(id);
            if (tblcustomerbooking == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.TblCustomerBookings.Remove(tblcustomerbooking);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tblcustomerbooking);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}