using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Client
    {
        public Object _id { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [Required]
        public string tel { get; set; }

        [Required]
        public int solde_bnq { get; set; }

        [Required]
        public bool historique { get; set; }

        [Required]
        public bool credit { get; set; }

    }
}