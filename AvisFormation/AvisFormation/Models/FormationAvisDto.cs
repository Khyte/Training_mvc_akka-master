using AvisFormation.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.Models
{
    public class FormationAvisDto
    {
        public double Note { get; set; }
        public Formation Formation { get; set; }
    }
}