using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerManagementSystem.Models;
using PagedList;
using PagedList.Mvc;

namespace CustomerManagementSystem.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();

        // GET: Status
        public ActionResult Index(string searchText, int? i)
        {
            //return View(db.tblStatus.ToList());

            int _pageNumber = 1;
            int _pageSize = 6;
            return View(db.tblStatus.Where(x => x.Status.StartsWith(searchText) || searchText == null).ToList().ToPagedList(i ?? _pageNumber, _pageSize));

        }

        // GET: Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status,Color")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                db.tblStatus.Add(tblStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStatus);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status,Color")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStatus);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatus.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStatus tblStatus = db.tblStatus.Find(id);
            db.tblStatus.Remove(tblStatus);
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
