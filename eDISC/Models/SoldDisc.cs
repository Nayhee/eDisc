using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eDISC.Models
{
    public class SoldDisc
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Disc")]
        public int DiscId { get; set; }

    }
}

