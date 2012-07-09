using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class BookingTest
    {
     public BookingTest()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookingContext>());
            //Database.SetInitializer<PanelContext>(null);
         Database.SetInitializer(new BookingInitialize());
        }

        [TestMethod]
        public void DropCreateDatabaseIfModelChanges()
        {
            var dbContext = new BookingContext();
            var listOfPanels = dbContext.TblCustomerBookings.ToList();
        }
    }
}
