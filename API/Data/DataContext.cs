using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data


{
    public class DataContext : DbContext
    {
        // contructor
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        // properties
        public DbSet<AppUser> Users { get; set; }
    }
}