using PogsRUs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Services
{
    public class CheckoutManagementService
    {
        private readonly PogsRUsDbContext _context;

        public CheckoutManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }
    }
}
