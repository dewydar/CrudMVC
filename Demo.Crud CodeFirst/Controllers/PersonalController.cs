using Demo.Crud_CodeFirst.Models;
using Demo.Crud_CodeFirst.Models.Code_First_Details;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Crud_CodeFirst.Controllers
{
    public class PersonalController : Controller
    {
        static CadeFirst db = new CadeFirst();
        // GET: Personal
        public ActionResult personalInfo()
        {
            return View(db.personalDetails.ToList());
        }
        public ActionResult Details (int id)
        {
            return PartialView(db.personalDetails.FirstOrDefault(a=>a.Id==id));
        }
        public ActionResult Update(int id)
        {
            return PartialView(db.personalDetails.FirstOrDefault(a => a.Id == id));
        }
        [HttpPost]
        public ActionResult Update(PersonalDetails person)
        {
            var p = db.personalDetails.FirstOrDefault(a => a.Id == person.Id);
            if (ModelState.IsValid)
            {
                p.Name = person.Name;
                p.Age = person.Age;
                p.Address = person.Address;
                p.Mail = person.Mail;

                db.SaveChanges();
                return RedirectToAction(nameof(personalInfo));
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var result = db.personalDetails.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                db.personalDetails.Remove(result);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(personalInfo));
        }
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(PersonalDetails person)
        {
            if (ModelState.IsValid)
            {
                db.personalDetails.Add(person);
                db.SaveChanges();
                return RedirectToAction(nameof(personalInfo));
            }
            return PartialView();
        }
    }
}