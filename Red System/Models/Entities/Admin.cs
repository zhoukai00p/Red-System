﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}