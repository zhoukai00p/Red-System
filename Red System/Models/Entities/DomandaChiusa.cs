using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class DomandaChiusa
    {
        public int ID { get; set; }
        public string Domanda { get; set; }
        public string OpzioneA { get; set; }
        public string OpzioneB { get; set; }
        public string OpzioneC { get; set; }
        public string OpzioneD { get; set; }
        public string OpzioneE { get; set; }
        public bool RispGiustaA { get; set; }
        public bool RispGiustaB { get; set; }
        public bool RispGiustaC { get; set; }
        public bool RispGiustaD { get; set; }
        public bool RispGiustaE { get; set; }
        public float Punteggio { get; set; }
        public int IDVerifica { get; set; }
    }
}