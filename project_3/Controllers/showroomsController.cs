using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project_3.Models;

namespace project_3.Controllers
{
    public class showroomsController : Controller
    {
        private ShowRoomManagerEntities db = new ShowRoomManagerEntities();

        // GET: showrooms
        public ActionResult Index()
        {
            var showrooms = db.showrooms.Include(s => s.Product);
            return View(showrooms.ToList());
        }

        // GET: showrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            showroom showroom = db.showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            return View(showroom);
        }

        // GET: showrooms/Create
        public ActionResult Create()
        {
            ViewBag.id_product = new SelectList(db.Products, "id_product", "name");
            return View();
        }

        // POST: showrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_showroom,name,address,phonenumber,email,id_product,id_company")] showroom showroom)
        {
            if (ModelState.IsValid)
            {
                db.showrooms.Add(showroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_product = new SelectList(db.Products, "id_product", "name", showroom.id_product);
            return View(showroom);
        }

        // GET: showrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            showroom showroom = db.showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_product = new SelectList(db.Products, "id_product", "name", showroom.id_product);
            return View(showroom);
        }

        // POST: showrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_showroom,name,address,phonenumber,email,id_product,id_company")] showroom showroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_product = new SelectList(db.Products, "id_product", "name", showroom.id_product);
            return View(showroom);
        }

        // GET: showrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            showroom showroom = db.showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            return View(showroom);
        }

        // POST: showrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            showroom showroom = db.showrooms.Find(id);
            db.showrooms.Remove(showroom);
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
