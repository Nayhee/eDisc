using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eDISC.Models
{
    public class DiscTag
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Disc")]
        public int DiscId { get; set; }

        [Required]
        [DisplayName("Tag")]
        public int TagId { get; set; }

    }
}
