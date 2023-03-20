using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class Log
    {
        [Key]
        [Display(Name = "Id")]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Operation")]
        public string Operation { get; set; }
        [Display(Name = "UpdateDate")]
        public DateTime UpdateDate { get; set; }

    }
}