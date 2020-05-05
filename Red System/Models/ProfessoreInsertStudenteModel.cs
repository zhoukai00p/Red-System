using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreInsertStudenteModel : BaseModel
    {
        public string LabelNome { get; set; }
        public string LabelCognome { get; set; }
        public string LabelClasse { get; set; }
        public string LabelButtonSend { get; set; }

        public List<Classi> Classe { get; set; }

        public List<SelectListItem> listaClassi { get; set; }
        public User Studente { get; set; }
        public int StudenteClasseId { get; set; }
        public IEnumerable<SelectListItem> listaClassi2{ get; set; }
        public Admin Professore { get; internal set; }
        public string ErrorNomeMessage { get; set; }
        public string ErrorCognomeMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}