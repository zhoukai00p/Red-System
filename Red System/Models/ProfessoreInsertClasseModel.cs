using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreInsertClasseModel : BaseModel
    {
        public string LabelNumero { get; set; }
        public string LabelSezione { get; set; }
        public string LabelIndirizzo { get; set; }
        public string LabelButtonSend { get; set; }

        public Classi Classe { get; set; }

        public Professore Professore { get; internal set; }
        public string ErrorNumeroMessage { get; set; }
        public string ErrorSezioneMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}