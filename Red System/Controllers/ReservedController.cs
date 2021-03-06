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
            model.Professore = (Professore)utenteLoggato;

            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
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
        public ActionResult ProfessoreInsertClasse(int id, ProfessoreInsertClasseModel model)
        {
            ProfessoreInsertClasseLabel(model);
            char x = char.ToUpper(model.Classe.Sezione);
            model.Classe.Sezione = x;
            model.Classe.Indirizzo = char.ToUpper(model.Classe.Indirizzo[0]) + model.Classe.Indirizzo.Substring(1).ToLower();
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
            model.Classe = DatabaseHelper.GetAllClasse();
            model.ListaClassi = Helper.Helper.PrendiClasse();
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
            model.Classe = DatabaseHelper.GetAllClasse();
            model.ListaClassi = Helper.Helper.PrendiClasse();
            SelectListItem x = model.ListaClassi.Where(t => t.Value == model.ListaClassiSelectedValue).FirstOrDefault();
            model.StudenteClasseId = Convert.ToInt32(x.Value);
            DatabaseHelper.InsertStudente(model.Studente, model.StudenteClasseId);

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
            var IDVerifica = Session["VerificaSelezionato"];
            model.Verifica = (Verifica)IDVerifica;
            model.ListaDomandaChiusa = DatabaseHelper.GetAllDomandaChiusaByVerifica(model.Verifica.ID);
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
            model.LabelPunteggio = "Punteggio Totale";
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreInsertDomanda(int id, ProfessoreInsertDomandaModel model)
        {
            ProfessoreInsertDomandaLabel(model);

            var IDVerifica = Session["VerificaSelezionato"];
            model.Verifica = (Verifica)IDVerifica;
            model.ListaDomandaChiusa = DatabaseHelper.GetAllDomandaChiusaByVerifica(model.Verifica.ID);
            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            if (model.ListaDomandaChiusa != null)
            {
                DatabaseHelper.InsertDomandeChiuse(model.DomandaChiusa, model.Verifica.ID);
                return RedirectToAction("ProfessoreInsertDomanda", "Reserved", new { model.Professore.ID });
            }

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
            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            if (model.Verifica != null)
            {
                return RedirectToAction("ProfessoreInsertDomanda", "Reserved", new { model.Professore.ID });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreSelezionaVerifica(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreSelezionaVerificaModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreSelezionaVerificaLabel(model);
            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();
            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        public static void ProfessoreSelezionaVerificaLabel(ProfessoreSelezionaVerificaModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";

            model.LabelNome = "Nome";
            model.LabelDescrizione = "Descrizione";
            model.LabelButtonSend = "Invia";
        }

        [HttpPost]
        public ActionResult ProfessoreSelezionaVerifica(int id, ProfessoreSelezionaVerificaModel model)
        {
            ProfessoreSelezionaVerificaLabel(model);

            model.ListaVerifica = DatabaseHelper.GetAllVerifica();
            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();
            SelectListItem x = model.ListaSelectVerifica.Where(t => t.Value == model.VerificaSelectedValue).FirstOrDefault();
            model.VerificaID = Convert.ToInt32(x.Value);

            Verifica verifica;
            verifica = DatabaseHelper.GetVerificaById(model.VerificaID);

            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            Session["VerificaSelezionato"] = verifica;
            if (verifica != null)
            {
                return RedirectToAction("ProfessoreInsertDomanda", "Reserved", new { model.Professore.ID });
            }

            return View(model);
        }

        public static void ProfessoreAssegnaVerificaLabel(ProfessoreAssegnaVerificaModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelClasse = "Classe";
            model.LabelVerifica = "Verifica";
            model.LabelSend = "Invia";
        }

        [HttpGet]
        public ActionResult ProfessoreAssegnaVerifica(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreAssegnaVerificaModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreAssegnaVerificaLabel(model);
            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();
            model.ListaSelectClasse = Helper.Helper.PrendiClasse();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProfessoreAssegnaVerifica(int id, ProfessoreAssegnaVerificaModel model)
        {
            ProfessoreAssegnaVerificaLabel(model);

            model.ListaVerifiche = DatabaseHelper.GetAllVerifica();
            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();
            SelectListItem x = model.ListaSelectVerifica.Where(t => t.Value == model.VerificaSelectedValue).FirstOrDefault();
            model.VerificaID = Convert.ToInt32(x.Value);

            model.ListaClassi = DatabaseHelper.GetAllClasse();
            model.ListaSelectClasse = Helper.Helper.PrendiClasse();
            SelectListItem y = model.ListaSelectClasse.Where(t => t.Value == model.ClasseSelectedValue).FirstOrDefault();
            model.ClasseID = Convert.ToInt32(y.Value);

            Verifica verifica;
            verifica = DatabaseHelper.GetVerificaById(model.VerificaID);

            Classe classe;
            classe = DatabaseHelper.GetClasseById(model.ClasseID);

            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            Session["VerificaSelezionato"] = verifica;
            Session["ClasseSelezionata"] = classe;
            if ((verifica != null) && (classe != null))
            {
                return RedirectToAction("ProfessoreConfermaAssegnaVerifica", "Reserved", new { model.Professore.ID });
            }

            return View(model);
        }

        public static void ProfessoreConfermaAssegnaVerificaLabel(ProfessoreConfermaAssegnaVerificaModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelButtonSend = "Conferma";
            model.LabelNome = "Nome";
            model.LabelCognome = "Cognome";
            model.LabelClasse = "Classe";
            model.LabelPassword = "Password";
        }

        [HttpGet]
        public ActionResult ProfessoreConfermaAssegnaVerifica(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreConfermaAssegnaVerificaModel();

            model.Classe = (Classe)Session["ClasseSelezionata"];
            model.Verifica = (Verifica)Session["VerificaSelezionato"];
            model.Professore = (Professore)utenteLoggato;

            model.ListaStudente = DatabaseHelper.GetAllStudenteByIDClasse(model.Classe.ID);
            model.ListaPassword = Helper.Helper.GeneraPassword(model.Verifica, model.ListaStudente);
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreConfermaAssegnaVerificaLabel(model);
            Session["Passwordgenerate"] = model.ListaPassword;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProfessoreConfermaAssegnaVerifica(int id, ProfessoreConfermaAssegnaVerificaModel model)
        {
            ProfessoreConfermaAssegnaVerificaLabel(model);
            model.ListaPassword = (List<Password>)Session["Passwordgenerate"];
            model.Classe = (Classe)Session["ClasseSelezionata"];
            model.ListaStudente = DatabaseHelper.GetAllStudenteByIDClasse(model.Classe.ID);

            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            if (model.ListaPassword.Count != 0)
            {
                foreach (var item in model.ListaPassword)
                {
                    DatabaseHelper.InsertPassword(item);
                }
            }

            return View(model);
        }

        public static void ProfessoreSelezionaClasseVisualizzaPunteggioLabel(ProfessoreSelezionaClasseVisualizzaPunteggioModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelButtonSend = "Avanti";
        }

        [HttpGet]
        public ActionResult ProfessoreSelezionaClasseVisualizzaPunteggio(int id,int verificaID)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreSelezionaClasseVisualizzaPunteggioModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreSelezionaClasseVisualizzaPunteggioLabel(model);

            model.ListaSelectClasse = Helper.Helper.PrendiClasseByIDVerifica(verificaID);
            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProfessoreSelezionaClasseVisualizzaPunteggio(int id,int verificaID, ProfessoreSelezionaClasseVisualizzaPunteggioModel model)
        { 
            model.ListaClasse = DatabaseHelper.GetAllClasse();
            model.ListaSelectClasse = Helper.Helper.PrendiClasseByIDVerifica(verificaID);
            SelectListItem y = model.ListaSelectClasse.Where(t => t.Value == model.ClasseSelectedValue).FirstOrDefault();
            model.ClasseID = Convert.ToInt32(y.Value);

            Classe classe;
            classe = DatabaseHelper.GetClasseById(model.ClasseID);

            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            if (classe != null)
            {
                return RedirectToAction("ProfessoreVisualizzaPunteggio", "Reserved", new { id = model.Professore.ID, verificaID = verificaID, classeID = classe.ID});
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ProfessoreVisualizzaPunteggio(int id, int verificaID)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreSelezionaClasseVisualizzaPunteggioModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreSelezionaClasseVisualizzaPunteggioLabel(model);

            model.ListaSelectClasse = Helper.Helper.PrendiClasseByIDVerifica(verificaID);
            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        public static void ProfessoreSelezionaVerificaVisualizzaPunteggioLabel(ProfessoreSelezionaVerificaVisualizzaPunteggioModel model)
        {
            model.Title = "Red system";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelButtonSend = "Avanti";
        }

        [HttpGet]
        public ActionResult ProfessoreSelezionaVerificaVisualizzaPunteggio(int id)
        {
            var utenteLoggato = Session["utenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginProfessore", "Home");
            }

            var model = new ProfessoreSelezionaVerificaVisualizzaPunteggioModel();

            model.Professore = (Professore)utenteLoggato;
            if (model.Professore.ID != id)
            {
                return RedirectToAction("HomeProfessore", "Reserved", new { model.Professore.ID });
            }

            ProfessoreSelezionaVerificaVisualizzaPunteggioLabel(model);

            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();

            //model.DomandeChiuse = DatabaseHelper.GetAllDomandeChiuse();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProfessoreSelezionaVerificaVisualizzaPunteggio(int id, ProfessoreSelezionaVerificaVisualizzaPunteggioModel model)
        {
            model.ListaVerifica = DatabaseHelper.GetAllVerifica();
            model.ListaSelectVerifica = Helper.Helper.PrendiVerifica();
            SelectListItem x = model.ListaSelectVerifica.Where(t => t.Value == model.VerificaSelectedValue).FirstOrDefault();
            model.VerificaID = Convert.ToInt32(x.Value);

            Verifica verifica;
            verifica = DatabaseHelper.GetVerificaById(model.VerificaID);

            var utenteLoggato = Session["utenteLoggato"];
            model.Professore = (Professore)utenteLoggato;
            if (verifica != null)
            {
                return RedirectToAction("ProfessoreSelezionaClasseVisualizzaPunteggio", "Reserved", new { id= model.Professore.ID, verificaID = verifica.ID });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Verifica(int id)
        {
            var utenteLoggato = Session["StudenteLoggato"];
            if (utenteLoggato == null)
            {
                return RedirectToAction("LoginStudente", "Home");
            }

            var model = new VerificaModel();
            model.Title = "Verifica";
            model.Text = "<strong>Bold</strong> normal";
            model.LabelDomanda = "Domanda";
            model.LabelOpzioneA = "A";
            model.LabelOpzioneB = "B";
            model.LabelOpzioneC = "C";
            model.LabelOpzioneD = "D";
            model.LabelOpzioneE = "E";

            model.Password = (Password)utenteLoggato;

            if (model.Password.ID != id)
            {
                return RedirectToAction("Verifica", "Reserved", new { model.Password.ID });
            }

            model.ListaDomandaChiusa = DatabaseHelper.GetAllDomandaChiusaByVerifica(model.Password.IDVerifica);
            model.ListaRispostaChiusa = Helper.Helper.GeneraDomande(model.ListaDomandaChiusa, model.Password.IDStudente);

            return View(model);
        }

        [HttpPost]
        public ActionResult Verifica(int id, VerificaModel model)
        {
            var utenteLoggato = Session["StudenteLoggato"];
            model.Password = (Password)utenteLoggato;
            foreach (var item in model.ListaRispostaChiusa)
            {
                DatabaseHelper.InsertRispostaChiusa(item);
                DatabaseHelper.RemovePassword(model.Password);
            }
            Session.Remove("StudenteLoggato");
            return RedirectToAction("Index", "Home");
        }
    }
}