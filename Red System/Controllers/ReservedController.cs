﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;
using Red_System.Helper;
using Red_System.Models;

namespace Red_System.Controllers
{
    public class ReservedController : Controller
    {
        // GET: ReservedProfessore
       [HttpGet]
       public ActionResult HomeProfessore(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfiloProfessoreModel();
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";
            model.Professore = (Admin)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID});
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreInsertClasse(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }


            var model = new ProfessoreInsertClasseModel();

            model.Professore = (Admin)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }
            ProfessoreInsertClasseLabel(model);

            return View(model);
        }

        public static void ProfessoreInsertClasseLabel(ProfessoreInsertClasseModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";

            model.LabelNumero = "Numero";
            model.LabelSezione = "Sezione";
            model.LabelIndirizzo = "Indirizzo";
            model.LabelButtonSend = "Send";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertClasse(int id,ProfessoreInsertClasseModel model)
        {
            ProfessoreInsertClasseLabel(model);
            DatabaseHelper.InsertClasse(model.Classe);
            return View(model);
        }
    }
}