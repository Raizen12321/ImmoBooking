using ImmoBooking.Data.Base;
using ImmoBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmoBooking.Models
{
    public class Property : IEntityBase
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string MainImageURL { get; set; }

        public DateTime AvailableStart { get; set; }

        public DateTime AvailableEnd { get; set; }

        public PropertyCategorie PropertyCategorie { get; set; }


        //Relationships

        public List<Property_Agent> Properties_Agents { get; set; }

        //Agencie
        public int AgencieId { get; set; }

        [ForeignKey("AgencieId")]
        public Agencie Agencie { get; set; }

        //Owner
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }



    }
}
