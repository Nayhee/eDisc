using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace eDISC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public List<Disc> Discs { get; set; }
    }
}
