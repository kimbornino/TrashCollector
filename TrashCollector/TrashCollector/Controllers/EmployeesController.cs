using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
    // GET: Employees

    public ActionResult Index()
        {
            //Customer cust = new Customer();
            var day = DateTime.Today.DayOfWeek;
            string stringDay = day.ToString();
            
            var currentUserId = User.Identity.GetUserId();

            var employee = db.Employees.Where(e => e.ApplicationUserId == currentUserId).FirstOrDefault();

            var CustomerList = db.Customers.Where(z => z.CustomerZip == employee.EmployeeZip && (z.DayOfWeek == stringDay || z.CustomPickUp == stringDay)).ToList();
            //new code
           
            //var employees = db.Employees.Include(e => e.ApplicationUser);
            return View(CustomerList);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {

            {
                Customer customer = null;
                if (id == null)
                {
                    // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    var FoundUserId = User.Identity.GetUserId();

                    customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                    return View();

                }

                else
                {
                    customer = db.Customers.Find(id);
                }

                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole");
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,EmployeeZip,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId(); 
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", employee.ApplicationUserId);
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", employee.CustomerId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
                return View();
            }

        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId, Name, Address, CustomerZip, DayOfWeek, PickupStartDate, PickupEndDate, ApplicationUserId, BillAmount, CustomPickUp, PickupCompleted")] Customer customer)
        {
            if (customer.PickupCompleted == true)
            {
                customer.BillAmount = customer.BillAmount + 10;
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);
        }
    

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      


        public ActionResult Map(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
                ViewBag.CustomerAddress = customer.Address;
                ViewBag.CustomerZip = customer.CustomerZip;
                return View(customer);
            }

        }
        //[HttpPost]
        //public ActionResult Map([Bind(Include = "CustomerId, Name, Address, CustomerZip, DayOfWeek, PickupStartDate, PickupEndDate, ApplicationUserId, BillAmount, CustomPickUp, PickupCompleted")] Customer customer)
        //{
          
        //    if (ModelState.IsValid)
        //    {
          
        //        return RedirectToAction("Map");
        //    }

        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
        //    return View(customer);
        //}

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
