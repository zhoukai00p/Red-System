using System;
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
            model.Professore = (Professore)utenteLoggato;
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

            model.Professore = (Professore)utenteLoggato;
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
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertClasse(int id,ProfessoreInsertClasseModel model)
        {
            ProfessoreInsertClasseLabel(model);
            char x = Char.ToUpper(model.Classe.Sezione);
            model.Classe.Sezione = x;
            model.Classe.Indirizzo = Char.ToUpper(model.Classe.Indirizzo[0]) + model.Classe.Indirizzo.Substring(1).ToLower();
            DatabaseHelper.InsertClasse(model.Classe);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreInsertStudente(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }


            var model = new ProfessoreInsertStudenteModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }
            ProfessoreInsertStudenteLabel(model);
            model.Classe = DatabaseHelper.GetAllClassi();
            model.listaClassi = Helper.Helper.PrendiClassi();
            return View(model);
        }

        public static void ProfessoreInsertStudenteLabel(ProfessoreInsertStudenteModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";

            model.LabelNome = "Nome";
            model.LabelCognome = "Cognome";
            model.LabelClasse = "Classe";
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertStudente(int id, ProfessoreInsertStudenteModel model)
        {
            ProfessoreInsertStudenteLabel(model);

            //System.Diagnostics.Debug.WriteLine("Valore: " + Convert.ToInt32(model.listaClassi2));
            model.Classe = DatabaseHelper.GetAllClassi();
            model.listaClassi = Helper.Helper.PrendiClassi();
            SelectListItem x = model.listaClassi.Where(t => t.Value == model.listaClassiSelectedValue).FirstOrDefault();
            model.StudenteClasseId = Convert.ToInt32(x.Value);

            //model.StudenteClasseId = Convert.ToInt32(model.listaClassiSelectedValue);
            DatabaseHelper.InsertStudente(model.Studente,model.StudenteClasseId);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreInsertDomanda(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }


            var model = new ProfessoreInsertDomandaModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }
            ProfessoreInsertDomandaLabel(model);
            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        public static void ProfessoreInsertDomandaLabel(ProfessoreInsertDomandaModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";

            model.LabelDomanda = "Domanda";
            model.LabelOpzioneA = "A";
            model.LabelOpzioneB = "B";
            model.LabelOpzioneC = "C";
            model.LabelOpzioneD = "D";
            model.LabelOpzioneE = "E";
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertDomanda(int id, ProfessoreInsertDomandaModel model)
        {
            ProfessoreInsertDomandaLabel(model);
            //DatabaseHelper.InsertDomandeChiuse(model.DomandaChiusa);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreInsertVerifica(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }


            var model = new ProfessoreInsertVerificaModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }
            ProfessoreInsertVerificaLabel(model);
            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        public static void ProfessoreInsertVerificaLabel(ProfessoreInsertVerificaModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";

            model.LabelNome = "Nome";
            model.LabelDescrizione = "Descrizione";
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertVerifica(int id, ProfessoreInsertVerificaModel model)
        {
            ProfessoreInsertVerificaLabel(model);
            model.Verifica.IDProfessore = id;
            DatabaseHelper.InsertVerifica(model.Verifica);
            Session["VerificaSelezionato"] = model.Verifica;
            if (model.Verifica!=null)
            {
                return RedirectToAction("ProfessoreInsertDomanda", "Reserved", new { model.Professore.ID });
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult Verifica()
        {
            var model = new VerificaModel();
            model.Title = "Verifica";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelDomanda = "Domanda";
            model.LabelOpzioneA = "A";
            model.LabelOpzioneB = "B";
            model.LabelOpzioneC = "C";
            model.LabelOpzioneD = "D";
            model.LabelOpzioneE = "E";
            model.DomandaChiusa = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }


    }
}