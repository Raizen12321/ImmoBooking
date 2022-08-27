using System.ComponentModel.DataAnnotations.Schema;

namespace ImmoBooking.Models
{
    public class Property_Agent
    {
        public int PropertyId { get; set; }


        [ForeignKey("PropertyId")]

        public Property Property { get; set; }


        //

        public int AgentId { get; set; }


        [ForeignKey("AgentId")]

        public Agent Agent { get; set; }


    }
}
