using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "VisitID")]
        [ScaffoldColumn(false)]
        public int VisitID { get; set; }

        [ForeignKey("Pet")]
        [Display(Name = "PetID")]
        public int pet_id { get; set; }

        [ForeignKey("Vet")]
        [Display(Name = "VetID")]
        public int VetID { get; set; }


        [Display(Name = "VisitDate")]
        public DateTime VisitDate { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual Vet Vet { get; set; }
    }
}