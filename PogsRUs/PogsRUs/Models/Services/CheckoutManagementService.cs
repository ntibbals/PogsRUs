using PogsRUs.Data;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Services
{
    public class CheckoutManagementService : ICheckout
    {
        private readonly PogsRUsDbContext _context;

        public CheckoutManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }
    }
}
