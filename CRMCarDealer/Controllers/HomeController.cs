using CRMCarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinesServices;
using DBModels;

namespace CRMCarDealer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CompletareDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CompletareDate(Person person)
        {
            ContactService contactService = new ContactService();
            Contact contact = new Contact(person.Email, person.Telephone);
            contactService.insert(contact);
            ProspectService prospectService = new ProspectService();
            prospectService.insert(new Prospect(person.FirstName + " " + person.LastName, "--",contact.id));
            return View("Index");
        }
    }
}