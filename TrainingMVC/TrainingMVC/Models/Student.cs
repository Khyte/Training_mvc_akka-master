using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingMVC.Models
{
    public class Student : ApplicationUser
    {
        public virtual List<Address> Addresses { get; set; }
    }
}