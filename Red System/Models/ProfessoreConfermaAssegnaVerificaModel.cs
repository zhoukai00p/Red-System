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
        public List<Classi> ListaClassi { get; set; }
        public List<Verifica> ListaVerifiche { get; set; }
        public string LabelSend { get; set; }
        public int VerificaID { get; set; }
        public int ClasseID { get; set; }
        public List<SelectListItem> ListaSelectVerifica { get; set; }
        public List<SelectListItem> ListaSelectClasse { get; set; }
        public Professore Professore { get; internal set; }
        public string ErrorMessage { get; set; }
    }
}