using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class RispostaChiusa
    {
        public int ID { get; set; }
        public bool RispStudenteA { get; set; }
        public bool RispStudenteB { get; set; }
        public bool RispStudenteC { get; set; }
        public bool RispStudenteD { get; set; }
        public bool RispStudenteE { get; set; }
        public float IDstudente { get; set; }
        public int IDDomanda { get; set; }
    }
}