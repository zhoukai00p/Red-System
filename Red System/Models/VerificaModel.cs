using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class VerificaModel : BaseModel
    {
        public List<DomandaChiusa> ListaDomandaChiusa { get; set; }
        public string LabelDomanda { get; set; }
        public string LabelOpzioneA { get; set; }
        public string LabelOpzioneB { get; set; }
        public string LabelOpzioneC { get; set; }
        public string LabelOpzioneD { get; set; }
        public string LabelOpzioneE { get; set; }
        public Verifica Verifica { get; set; }
    }
}