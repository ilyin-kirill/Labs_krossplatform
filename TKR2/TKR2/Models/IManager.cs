using System;
using System.Collections.Generic;

namespace TKR2.Models
{
    public interface IManager
    {
        Driver SelectDriverForUser(User user, List<Driver> drivers);
    }
}
