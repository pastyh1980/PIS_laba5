using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Laba1.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> persons { get; set; }
    }
}