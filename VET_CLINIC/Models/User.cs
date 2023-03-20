using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "UserId")]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string SurName { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }

    }
}