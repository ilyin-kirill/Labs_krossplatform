using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } 
        public double Rating { get; set; }
        public List<Ride> Rides { get; set; } = new List<Ride>();
        public bool ChangeAddressTo(int id, string address_new)
        {
            var i = Rides.FirstOrDefault(r => r.Id == id);
            if (i != null)
            {
                i.AddressTo = address_new;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
