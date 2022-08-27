using ImmoBooking.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImmoBooking.Models
{
    public class Owner:IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name ="Photo de Profil")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Nom")]
        public string FullName { get; set; }

        //Relationships

        public List<Property> Properties { get; set; }

    }
}
