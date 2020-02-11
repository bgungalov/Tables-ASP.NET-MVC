using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tables.Models
{
    public class BiserrDbContext : DbContext
    {
            public DbSet<Employee> Employee { get; set; }
            public DbSet<Project> Project { get; set; }
            public DbSet<EmployeeProject> EmployeeProject { get; set; }
    }
}