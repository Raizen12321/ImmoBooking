using ImmoBooking.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImmoBooking.Models
{
    public class Agencie: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo is Required")]
        public string LogoURL { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez saisir le Nom de l'agence")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le Nom doit être entre 3 et 50 caratères")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Veuillez saisir l'adresse Email")]
        public string Email { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Veuillez Décrire l'agence")]
        public string Description { get; set; }



        //Relationships
        public List<Property> Properties { get; set; }


    }
}
