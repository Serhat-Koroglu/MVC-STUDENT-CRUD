using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Ogrenci.Models;

namespace Mvc_Ogrenci.Controllers
{
    public class OgrenciController : Controller
    {
        private Db_Mvc_OgnreciEntities db = new Db_Mvc_OgnreciEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            return View(db.Table_Ogrenci.ToList());
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Ogrenci table_Ogrenci = db.Table_Ogrenci.Find(id);
            if (table_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(table_Ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrID,OgrAd,OgrSoyad,OgrMail,OgrFotograf,OgrAdres")] Table_Ogrenci table_Ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Table_Ogrenci.Add(table_Ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Ogrenci table_Ogrenci = db.Table_Ogrenci.Find(id);
            if (table_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(table_Ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrID,OgrAd,OgrSoyad,OgrMail,OgrFotograf,OgrAdres")] Table_Ogrenci table_Ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Ogrenci table_Ogrenci = db.Table_Ogrenci.Find(id);
            if (table_Ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(table_Ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Ogrenci table_Ogrenci = db.Table_Ogrenci.Find(id);
            db.Table_Ogrenci.Remove(table_Ogrenci);
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
