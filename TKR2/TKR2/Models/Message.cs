using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Mess { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
