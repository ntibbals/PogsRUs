using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.ViewModels
{
    public class ProfileViewModel
    {

        public ICollection<Order> Orders { get; set; }
    }
}
