using E4DataCapture.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E4DataCapture.Helpers;

using System.Xml.Serialization;

namespace E4DataCapture.Controllers
{
    public class HomeController : Controller
    {
        public XMLHelper xml = new XMLHelper();
        public ActionResult Index()
        {


            List<User> users = xml.getAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(string name, string surname, string cellNumber)
        {

            User usr = new User()
            {
                Name = name,
                Surname = surname,
                CellNumber = cellNumber,
                UserID = System.Guid.NewGuid().ToString() // generates a unique key
            };

            xml.addUser(usr);
            return RedirectToAction("Index", new { });
        }

        public ActionResult Edit(User usr)
        {
            return View(usr);
        }

        [HttpPost]
        public ActionResult Edit(string userID, string name, string surname, string cellnumber)
        {
            User usr = new User()
            {
                UserID = userID,
                Name = name,
                Surname = surname,
                CellNumber = cellnumber
            };
            xml.editUser(usr);
            
            return RedirectToAction("Index", new { });
        }
        public ActionResult Delete(string id)
        {
            xml.deleteUser(id);
            return RedirectToAction("Index", new { });
        }


        

    }
}

