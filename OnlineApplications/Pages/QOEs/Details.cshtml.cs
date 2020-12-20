using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineApplications.Data;
using OnlineApplications.Models;

namespace OnlineApplications.QOEs
{
    public class DetailsModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public DetailsModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public QualificationOnEntry QualificationOnEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QualificationOnEntry = await _context.QualificationOnEntry
                .Include(q => q.Application).FirstOrDefaultAsync(m => m.QualificationOnEntryID == id);

            if (QualificationOnEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
