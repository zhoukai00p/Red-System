using Red_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models
{
    public class ProfessoreInsertVerificaModel : BaseModel
    {
        public string LabelNome { get; set; }
        public string LabelDescrizione { get; set; }
        public string LabelButtonSend { get; set; }
        public Verifica Verifica { get; set; }
        public Professore Professore { get; set; }
        public int IDProfessore { get; set; }
        public string ErrorMessage { get; set; }
    }
}