using ImmoBooking.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ImmoBooking.Models
{
    public class Agent:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Photo de Profil")]
        [Required(ErrorMessage ="Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }
        

        [Display(Name = "Nom")]
        [Required(ErrorMessage ="Veuillez saisir le Nom complet de l'agent")]
        [StringLength(50,MinimumLength =3,ErrorMessage = "Le Nom doit être entre 3 et 50 caratères")]
        public string FullName { get; set; }
        
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Veuillez saisir l'adresse Email")]

        public string Email { get; set; }
        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Veuillez saisir le Contact de l'agent")]

        public string Contact { get; set; }

        public List<Property_Agent> Properties_Agents { get; set; }

    }
}
