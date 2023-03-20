using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class Vet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "VetID")]
        [ScaffoldColumn(false)]
        public int VetID { get; set; }

        [Display(Name = "VetName")]
        public string VetName { get; set; }

        [Display(Name = "VetSurName")]
        public string VetSurName { get; set; }

        [Display(Name = "Identity Number")]
        public long ID_Number { get; set; }

        [Display(Name = "Medical License Number")]
        public string MedicalLicenseNumber { get; set; }



    }
}