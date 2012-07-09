using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcApplication2.Models;

namespace MvcApplication2
{
    public class BookingContext : DbContext
    {
        public BookingContext(): base("name=BookingContext"){}

        public DbSet<TblCustomerBooking> TblCustomerBookings { get; set; }
    }

    public class BookingInitialize : DropCreateDatabaseAlways<BookingContext>
    {
        protected override void Seed(BookingContext context)
        {
            new List<TblCustomerBooking>
                {
                    new TblCustomerBooking
                        {
                            customer_email = "some@some.com",
                            customer_name = "First name",
                            TblRentals = new List<TblRental>
                                {
                                    new TblRental
                                        {
                                            room_id = 2,
                                            room_cost = 34m,
                                            check_in = new DateTime(2012,3,23),
                                            check_out = new DateTime(2012,7,22)                                     
                                        }
                                }

                        },
                        new TblCustomerBooking
                        {
                            customer_email = "some@some.com",
                            customer_name = "Second name",
                            TblRentals = new List<TblRental>
                                {
                                    new TblRental
                                        {
                                            room_id = 2,
                                            room_cost = 34m,
                                            check_in = new DateTime(2012,3,23),
                                            check_out = new DateTime(2012,7,22)                                     
                                        }
                                }

                        }
                }.ForEach(b => context.TblCustomerBookings.Add(b));
            base.Seed(context);
        }
    }
}