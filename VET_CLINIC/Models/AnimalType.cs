using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class AnimalType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "AnimalTypeID")]
        [ScaffoldColumn(false)]
        public int AnimalTypeID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}