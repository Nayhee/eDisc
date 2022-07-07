using System;
using System.Collections.Generic;

namespace eDISC.Models.ViewModels
{
    public class DiscCartViewModel
    {
        public List<Disc> Discs { get; set; }
        public Cart Cart { get; set; }

        public User User { get; set; }
    }
}
