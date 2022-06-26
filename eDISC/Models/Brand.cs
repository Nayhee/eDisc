using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eDISC.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Add a Brand Name!")]
        [MaxLength(35)]
        public string Name { get; set; }

    }
}
