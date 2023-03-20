using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PetID")]
        [ScaffoldColumn(false)]
        public int pet_id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("AnimalType")]
        [Display(Name = "AnimalTypeID")]
        public int AnimalTypeID { get; set; }


        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [ForeignKey("PetOwner")]
        [Display(Name = "onwer_id")]
        public int onwer_id { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string Birthdate{ get; set; }


        public virtual AnimalType AnimalType { get; set; }
        public virtual PetOwner PetOwner { get; set; }
    }
}