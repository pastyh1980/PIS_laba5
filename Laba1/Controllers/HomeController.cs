using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laba1.Models;
using System.Data.Entity;

namespace Laba1.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db = new PersonContext();
        public ActionResult Index()
        {
            IEnumerable<Person> persons = db.persons;
            ViewBag.Persons = persons;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View();
            Person person = db.persons.FirstOrDefault(p => p.id == id);
            if (person != null)
            {
                return View(person);
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (person.id > 0)
                db.Entry(person).State = EntityState.Modified;
            else
                db.Entry(person).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Person p = new Person { id = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}