using Red_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Red_System.Models
{
    public class ProfessoreConfermaAssegnaVerificaModel : BaseModel
    {
        public Classe Classe { get; set; }
        public Verifica Verifica { get; set; }
        public string LabelSend { get; set; }
        public int VerificaID { get; set; }
        public int ClasseID { get; set; }
        public Professore Professore { get; internal set; }
        public List<Studente> ListaStudente { get; set; }
        public List<Password> ListaPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}