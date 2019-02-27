﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.ViewModels
{

        public class ExternalLoginViewModel
        {
            [EmailAddress]
            [Required]
            public string Email { get; set; }
        }
  
}
