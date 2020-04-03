using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laba1.Models;
using System.Data.Entity;

namespace Laba1.Controllers
{
    /*Основной контроллер*/
    public class HomeController : Controller
    {
        /*Создание объекта класса DbContext*/
        PersonContext db = new PersonContext();

        /*Вывод телефонной книги и поиск по запросу*/
        public ActionResult Index(string query)
        {
            IEnumerable<Person> persons = db.persons;
            if (!String.IsNullOrEmpty(query))
            {
                ViewBag.QueryString = query;
                /*Применение фильтра*/
                persons = persons.Where(p => p.firstName.ToUpper().Contains(query.ToUpper())
                                          || p.lastName.ToUpper().Contains(query.ToUpper())
                                          || p.secondName.ToUpper().Contains(query.ToUpper())
                                          || p.phone.ToUpper().Contains(query.ToUpper()));
            }
            ViewBag.Persons = persons;
            return View();
        }

        /*Запрос формы на редактирование записи телеофнной книги*/
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

        /*Изменения записи в БД после редактирования*/
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            ModelState["id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                /*Возврат на форму редактирования, если есть ошибки заполнения*/
                return View(person);
            }
            if (person.id > 0) /*Создание или редактирование*/
                db.Entry(person).State = EntityState.Modified;
            else
                db.Entry(person).State = EntityState.Added;
            /*Коммит в БД*/
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*Удаление записи*/
        public ActionResult Delete(int id)
        {
            Person p = new Person { id = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}