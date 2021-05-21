using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class Taxi
    {
        public int Id { get; set; }
        public string Carname { get; set; }
        public string Number { get; set; }
        public Driver Driver { get; set; }
    }
}
