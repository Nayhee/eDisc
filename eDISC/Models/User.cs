using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eDISC.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Type")]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public List<Disc> SoldDiscs { get; set; } = new List<Disc>();

    }
}
