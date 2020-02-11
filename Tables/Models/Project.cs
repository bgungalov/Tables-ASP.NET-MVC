using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tables.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDetails { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}