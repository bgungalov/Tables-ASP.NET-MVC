using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tables.Models;

namespace Tables.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private BiserrDbContext db = new BiserrDbContext();

        // GET: EmployeeProjects
        public ActionResult Index()
        {
            var employeeProject = db.EmployeeProject.Include(e => e.Employee).Include(e => e.Project);
            return View(employeeProject.ToList());
        }

        public ActionResult CreateProjectEmployee()
        {
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName");
            ViewBag.Employees = db.Employee;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProjectEmployee(int ProjectId, int []EmployeeIds)
        {
            foreach (int empId in EmployeeIds)
            {
                EmployeeProject empProject = new EmployeeProject();
                empProject.ProjectId = ProjectId;
                empProject.EmployeeId = empId;
                db.EmployeeProject.Add(empProject);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: EmployeeProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName");
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeProject.Add(employeeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProject employeeProject = db.EmployeeProject.Find(id);
            db.EmployeeProject.Remove(employeeProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
