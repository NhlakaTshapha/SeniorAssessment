using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VET_CLINIC.Models
{
    public class PetOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "OwnerID")]
        [ScaffoldColumn(false)]
        public int onwer_id { get; set; }

        [Display(Name = "OwnerName")]
        public string OwnerName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Phone number")]
        public int Phone_number { get; set; }

        [Display(Name = "Email address")]
        public string Email_address { get; set; }

        [StringLength(10000), Display(Name = "Postal Address"), DataType(DataType.MultilineText)]
        public string Postal_Address { get; set; }

        [Display(Name = "Identity Number")]
        public long ID_Number { get; set; }

        [Display(Name = "Account Number")]
        public long AccountNumber { get; set; }



        


    }
}