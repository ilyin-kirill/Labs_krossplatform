using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public List<Ride> Rides = new List<Ride>();
    }
}
