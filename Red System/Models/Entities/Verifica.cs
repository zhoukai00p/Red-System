using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class Verifica
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public int IDProfessore { get; set; }
    }
}