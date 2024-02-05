using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fresh_Express.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Fresh_Express.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            int userId = DbHelper.InsertUser(user);

            ViewBag.Message = userId > 0 ? "Registration successful" : "Registration failed";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            bool isValidUser = DbHelper.ValidateUser(username, password);

            if (isValidUser)
            {
                // Successful login, redirect to a dashboard or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Failed login, show an error message
                ViewBag.Message = "Invalid username or password";
                return View();
            }
        }

    }
}