using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuzeeApi.Models
{
    public class DBBase : ApplicationDbContext
    {
        public DBBase() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}