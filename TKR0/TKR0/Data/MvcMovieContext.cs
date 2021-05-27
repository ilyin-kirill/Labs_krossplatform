using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKR0.Models;
using Microsoft.EntityFrameworkCore;

namespace TKR0.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
