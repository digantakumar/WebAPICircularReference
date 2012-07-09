using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class TblCustomerBooking
    {
        [Key()]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public virtual ICollection<TblRental> TblRentals { get; set; }
    }
}