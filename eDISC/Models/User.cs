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

        public string IsAdmin { get; set; }

        public List<SoldDisc> SoldDiscs { get; set; } = new List<SoldDisc>();

    }
}
