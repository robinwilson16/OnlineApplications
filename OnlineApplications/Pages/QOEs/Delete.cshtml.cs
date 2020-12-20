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
    public class DeleteModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public DeleteModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QualificationOnEntry = await _context.QualificationOnEntry.FindAsync(id);

            if (QualificationOnEntry != null)
            {
                _context.QualificationOnEntry.Remove(QualificationOnEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
