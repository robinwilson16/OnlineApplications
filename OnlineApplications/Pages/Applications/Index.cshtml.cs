using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineApplications.Data;
using OnlineApplications.Models;

namespace OnlineApplications
{
    public class IndexModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public IndexModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; }

        public async Task OnGetAsync()
        {
            Application = await _context.Application.ToListAsync();
        }
    }
}
