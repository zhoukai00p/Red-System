using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfessoreInsertDomandaModel : BaseModel
    {
        public string LabelDomanda { get; set; }
        public string LabelOpzioneA { get; set; }
        public string LabelOpzioneB { get; set; }
        public string LabelOpzioneC { get; set; }
        public string LabelOpzioneD { get; set; }
        public string LabelOpzioneE { get; set; }
        public string LabelPunteggio { get; set; }
        public string LabelButtonSend { get; set; }
        public string ErrorMessage { get; set; }
        public Professore Professore { get; internal set; }
        public DomandaChiusa DomandaChiusa { get; set; }

        public Classi Classe { get; set; }
    }
}