using ImmoBooking.Data.Base;
using ImmoBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmoBooking.Models
{
    public class NewPropertyVM
    {
        public int Id { get; set; }

        [Display(Description = "Nom de la propriété",Name ="Nom")]
        [Required(ErrorMessage = "Le Nom de la propriété est obligatoire")]
        public string Name { get; set; }

        [Display(Description = "Description de la propriété")]
        [Required(ErrorMessage = "La Description de la propriété est obligatoire")]
        public string Description { get; set; } 

        [Display(Description = "Prix de la propriété", Name = "Prix")]
        [Required(ErrorMessage = "Le Prix de la propriété est obligatoire")]
        public double Price { get; set; }

        [Display(Description = "Image principale de la propriété URL", Name = "Photo Principale")]
        [Required(ErrorMessage = "L'URL de la photo de la propriété est obligatoire")]
        public string MainImageURL { get; set; }

        [Display(Description = "La date de début de disponibilité", Name = "Début")]
        [Required(ErrorMessage = "Le date de début de disponibilité de la propriété est obligatoire")]
        public DateTime AvailableStart { get; set; }

        [Display(Description = "La date de fin de disponibilité", Name = "Fin")]
        [Required(ErrorMessage = "Le date de fin de disponibilité de la propriété est obligatoire")]
        public DateTime AvailableEnd { get; set; }

        [Display(Description = "Choisir une Catégorie", Name = "Catégorie")]
        [Required(ErrorMessage = "La Catégorie de la propriété est obligatoire")]
        public PropertyCategorie PropertyCategorie { get; set; }

        //Relationships
        [Display(Description = "Choisir un agent(s)", Name = "Agent(s)")]
        [Required(ErrorMessage = "L'agent responsable est obligatoire")]
        public List<int> AgentIds { get; set; }

        [Display(Description = "Choisir un agence", Name = "Agence")]
        [Required(ErrorMessage = "L'agence est obligatoire")]
        public int AgencieId { get; set; }

        [Display(Description = "Choisir un propriétaire", Name = "Propriétaire")]
        [Required(ErrorMessage = "Le propriétaire est obligatoire")]
        public int OwnerId { get; set; }
    }
}
