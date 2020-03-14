using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models;
using Red_System.Models.Entities;
using Red_System.Helper;

namespace Red_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexModel();
            model.Title = "Red System";
            model.Text = "<strong>Bold</strong> normal";
            ViewBag.Title = "Homepage";
            return View();
        }

        [HttpGet]
        public ActionResult LoginProfessore()
        {
            var model = new LoginProfessoreModel();
            model.Title = "Red System";
            model.Text = "<strong>Bold</strong> normal";

            model.LoginLabel = "Login";
            model.UsernameLabel = "Username";
            model.PasswordLabel = "Password";
            model.SendLabel = "Send";
            return View(model);
        }

        [HttpPost]
        public ActionResult LoginProfessore(LoginProfessoreModel model)
        {
            model.Title = "Red System";
            model.Text = "<strong>Bold</strong> normal";

            model.LoginLabel = "LoginProfessore Post";
            model.UsernameLabel = "Username";
            model.PasswordLabel = "Password";
            model.SendLabel = "Send";
            var professore = DatabaseHelper.Login(model.Username, model.Password);
            if (professore != null)
            {

                Session["utenteLoggato"] = professore;

                return RedirectToAction("HomeProfessore", "Reserved", new { id = professore.ID });
            }
            model.ErrorMessage = "Wrong login!";

            return View(model);
        }

    }
}