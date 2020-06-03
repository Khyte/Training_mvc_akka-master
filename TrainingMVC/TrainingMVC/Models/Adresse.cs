using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMVC.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string NumeroRue { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public virtual CustomUser User { get; set; }
    }
}