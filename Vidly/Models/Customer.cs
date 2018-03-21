using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membershipy Type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearIsMember]
        public DateTime? Birthday { get; set; }

    }
}