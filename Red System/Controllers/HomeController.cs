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
            LoginProfessoreLable(model);
            return View(model);
        }

        public static void LoginProfessoreLable(LoginProfessoreModel model)
        {
            model.Title = "Red System";
            model.Text = "<strong>Bold</strong> normal";
            model.LoginLabel = "Login";
            model.UsernameLabel = "Username";
            model.PasswordLabel = "Password";
            model.SendLabel = "Invia";
        }

        [HttpPost]
        public ActionResult LoginProfessore(LoginProfessoreModel model)
        {
            LoginProfessoreLable(model);
            var professore = DatabaseHelper.LoginProfessore(model.Username, model.Password);
            if (professore != null)
            {
                Session["utenteLoggato"] = professore;
                return RedirectToAction("HomeProfessore", "Reserved", new { id = professore.ID });
            }

            model.ErrorMessage = "Dati errati!";
            return View(model);
        }

        public static void LoginStudenteLable(LoginStudenteModel model)
        {
            model.Title = "Red System";
            model.Text = "<strong>Bold</strong> normal";
            model.LoginLabel = "Login";
            model.PasswordLabel = "Password";
            model.SendLabel = "Invia";
        }

        [HttpGet]
        public ActionResult LoginStudente()
        {
            var model = new LoginStudenteModel();
            LoginStudenteLable(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult LoginStudente(LoginProfessoreModel model)
        {
            LoginProfessoreLable(model);
            var studente = DatabaseHelper.LoginStudente(model.Password);
            if (studente != null)
            {
                Session["StudenteLoggato"] = studente;
                return RedirectToAction("Verifica", "Reserved", new { id = studente.ID });
            }
            model.ErrorMessage = "Dati errati!";
            return View(model);
        }
    }
}