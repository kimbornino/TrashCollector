﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using TrashCollector.Operations;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //new code
        //private Geocoder geocoder = new Geocoder();

        // GET: Customers
        public ActionResult Index()
        {
            var FoundUserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
            // ApplicationUser
            var customers = db.Customers.Include(c => c.ApplicationUser);
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer = null;
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var FoundUserId = User.Identity.GetUserId();
                
                customer = db.Customers.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(customer);
                
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

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Name,Address,CustomerZip,DayOfWeek,PickupStartDate,PickupEndDate,CustomPickUp,PickupCompleted,ApplicationUserId,ApplicationUser")] Customer customer)
        {
            
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();

            if (ModelState.IsValid)
            {
                //code edited here.  it was equal to test
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                // SUSPICIOUS!!!!!!
                //Geocoder.RunGeocoder(customer.Address, customer.CustomerZip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
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
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Name,Address,CustomerZip,DayOfWeek,PickupStartDate,PickupEndDate, ApplicationUserId,BillAmount, CustomPickUp, PickupCompleted")] Customer customer)

        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserRole", customer.ApplicationUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
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
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
