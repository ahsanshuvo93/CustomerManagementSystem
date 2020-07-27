using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerManagementSystem;
using CustomerManagementSystem.Models;
using PagedList;
using PagedList.Mvc;

namespace CustomerManagementSystem.Controllers
{
    [Authorize]
    public class SourcesController : Controller
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();

        // GET: Sources
        public ActionResult Index(string searchText, int? i)
        {
            //return View(db.tblSource.ToList());

            int _pageNumber = 1;
            int _pageSize = 6;
            return View(db.tblSource.Where(x => x.Source.StartsWith(searchText) || searchText == null).ToList().ToPagedList(i ?? _pageNumber, _pageSize));
        }

        // GET: Sources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSource tblSource = db.tblSource.Find(id);
            if (tblSource == null)
            {
                return HttpNotFound();
            }
            return View(tblSource);
        }

        // GET: Sources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Source,Color")] tblSource tblSource)
        {
            if (ModelState.IsValid)
            {
                db.tblSource.Add(tblSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSource);
        }

        // GET: Sources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSource tblSource = db.tblSource.Find(id);
            if (tblSource == null)
            {
                return HttpNotFound();
            }
            return View(tblSource);
        }

        // POST: Sources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Source,Color")] tblSource tblSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSource);
        }

        // GET: Sources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSource tblSource = db.tblSource.Find(id);
            if (tblSource == null)
            {
                return HttpNotFound();
            }
            return View(tblSource);
        }

        // POST: Sources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSource tblSource = db.tblSource.Find(id);
            db.tblSource.Remove(tblSource);
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
