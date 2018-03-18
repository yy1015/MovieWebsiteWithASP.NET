using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }





        public byte MemberShipTypeId { get; set; }


        // [Min18YearIsMember]
        public DateTime? Birthday { get; set; }
    }
}