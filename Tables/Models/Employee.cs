using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tables.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string MobileNO { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}