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
    public class ClientsController : Controller
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();

        // GET: Clients
        public ActionResult Index(string searchText, int? i)
        {
            int _pageNumber = 1;
            int _pageSize = 6;
            return View(db.tblClient.Where(x=>x.Name.StartsWith(searchText) || searchText == null ).ToList().ToPagedList(i ?? _pageNumber,_pageSize));
        }
        
        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return HttpNotFound();
            }
            return View(tblClient);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var _lstAgent = db.tblAgent.ToList();
            ViewBag.Agent = new SelectList(_lstAgent, "Name", "Name");

            var _lstSource = db.tblSource.ToList();
            ViewBag.Source = new SelectList(_lstSource, "Source", "Source");

            var _lstStatus = db.tblStatus.ToList();
            ViewBag.Status = new SelectList(_lstStatus, "Status", "Status");

            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Screen,Product,Company,Message,Agent,Status,Source,IP,StartDate,EndDate")] tblClient tblClient)
        {
            if (ModelState.IsValid)
            {
                tblClient.StartDate = tblClient.StartDate.Date;

                db.tblClient.Add(tblClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblClient);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            var _lstAgent = db.tblAgent.ToList();
            ViewBag.Agent = new SelectList(_lstAgent, "Name", "Name");

            var _lstSource = db.tblSource.ToList();
            ViewBag.Source = new SelectList(_lstSource, "Source", "Source");

            var _lstStatus = db.tblStatus.ToList();
            ViewBag.Status = new SelectList(_lstStatus, "Status", "Status");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblClient tblClient = db.tblClient.Find(id);

            if (tblClient == null)
            {
                return HttpNotFound();
            }

            return View(tblClient);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Screen,Product,Company,Message,Agent,Status,Source,IP,StartDate,EndDate")] tblClient tblClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblClient);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return HttpNotFound();
            }
            return View(tblClient);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClient tblClient = db.tblClient.Find(id);
            db.tblClient.Remove(tblClient);
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
