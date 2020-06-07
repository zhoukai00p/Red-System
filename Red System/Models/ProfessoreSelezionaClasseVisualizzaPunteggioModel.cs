using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreSelezionaClasseVisualizzaPunteggioModel : BaseModel
    {
        public string LabelClasse { get; set; }
        public Professore Professore { get; internal set; }
        public Verifica verifica { get; set; }
        public List<Classe> ListaClasse { get; set; }
        public string ClasseSelectedValue { get; set; }
        public List<SelectListItem> ListaSelectClasse { get; set; }
        public int ClasseID { get; set; }
        public string LabelButtonSend { get; set; }
    }
}