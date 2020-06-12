using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreVisualizzaPunteggioModel : BaseModel
    {
        public string LabelNome { get; set; }
        public string LabelCognome { get; set; }
        public string LabelClasse { get; set; }
        public string LabelClasse { get; set; }
        public Professore Professore { get; internal set; }
        public Verifica verifica { get; set; }
        public List<Studente> ListaStudente { get; set; }
        public string LabelButtonSend { get; set; }
    }
}