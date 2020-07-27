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
    public class AgentsController : Controller
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();

        // GET: Agents
        public ActionResult Index(string searchText, int? i)
        {
            int _pageNumber = 1;
            int _pageSize = 6;

            //return View(db.tblAgent.ToList());
            return View(db.tblAgent.Where(x => x.Name.StartsWith(searchText) || searchText == null).ToList().ToPagedList(i ?? _pageNumber, _pageSize));

        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAgent tblAgent = db.tblAgent.Find(id);
            if (tblAgent == null)
            {
                return HttpNotFound();
            }
            return View(tblAgent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Color")] tblAgent tblAgent)
        {
            if (ModelState.IsValid)
            {
                db.tblAgent.Add(tblAgent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAgent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAgent tblAgent = db.tblAgent.Find(id);
            if (tblAgent == null)
            {
                return HttpNotFound();
            }
            return View(tblAgent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Color")] tblAgent tblAgent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAgent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAgent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAgent tblAgent = db.tblAgent.Find(id);
            if (tblAgent == null)
            {
                return HttpNotFound();
            }
            return View(tblAgent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAgent tblAgent = db.tblAgent.Find(id);
            db.tblAgent.Remove(tblAgent);
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
