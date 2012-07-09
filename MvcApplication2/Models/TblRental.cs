using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication2.Models
{
    public class TblRental
    {
        [Key()]
        public int rental_id { get; set; }
        public int room_id { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public decimal room_cost { get; set; }
        public int customer_id { get; set; }
        [ForeignKey("customer_id")]
        public virtual TblCustomerBooking tblCustomerBooking { get; set; }
    }
}