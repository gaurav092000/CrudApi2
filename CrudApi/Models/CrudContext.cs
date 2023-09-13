using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudApi.Models
{
    public class CrudContext : DbContext
    {
        public  CrudContext() : base("CrudApi") { }  

        public DbSet<Student> std { get; set; }
     }
}