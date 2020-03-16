using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class DomandeChiuse
    {
        public int ID { get; set; }
        public string Domanda { get; set; }
        public string OpzioneA { get; set; }
        public string OpzioneB { get; set; }
        public string OpzioneC { get; set; }
        public string OpzioneD { get; set; }
        public string OpzioneE { get; set; }
        public int IDStudente { get; set; }
        public int IDProfessore { get; set; }
    }
}