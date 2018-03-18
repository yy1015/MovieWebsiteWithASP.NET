using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MemberShipType
    {
        [Key]
        public int Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DiscountRate { get; set; }

        public byte DurationMonths { get; set; }

        public string Name { get; set; }



        public static readonly byte unKnown = 0;

        public static readonly byte PayAsYouGo = 1;
    }
}