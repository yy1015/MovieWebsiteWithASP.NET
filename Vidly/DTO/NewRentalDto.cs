using System.Collections.Generic;

namespace Vidly.DTO
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }

        public List<int> MovieId { get; set; }
    }
}