using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public void CalcPrice()
        {
            Price = Convert.ToInt32(70 + (TimeEnd - TimeBegin).TotalMinutes * 5);
        }
        public void ChangeAddressTo(string address_new)
        {
            AddressTo = address_new;
        }
    }
}
