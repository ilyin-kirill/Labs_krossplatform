using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKR2.Models
{
    public class Manager : IManager
    {
        public Driver SelectDriverForUser(User user, List<Driver> drivers)
        {
            var r = new Random();
            var selected_drivers = drivers.Where(driver => driver.Rating >= user.Rating-0.25 && driver.Rating <= user.Rating + 0.5).ToList();
            var selected_driver = selected_drivers.ElementAt(r.Next(0, selected_drivers.Count()));
            if (selected_driver==null)
            {
                selected_driver = drivers.ElementAt(r.Next(0, drivers.Count()));
            }
            return selected_driver;
        }
    }
}
