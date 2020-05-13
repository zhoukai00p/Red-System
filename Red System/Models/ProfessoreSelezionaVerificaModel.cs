using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreSelezionaVerificaModel : BaseModel
    {
        public string LabelNome { get; set; }
        public string LabelDescrizione { get; set; }
        public string LabelButtonSend { get; set; }
        public Professore Professore { get; internal set; }
        public List<Verifica> ListaVerifica { get; set; }
        public List<SelectListItem> ListaSelectVerifica { get; set; }
        public string VerificaSelectedValue { get; set; }
        public string ErrorMessage { get; set; }
        public int VerificaID { get; set; }
    }
}