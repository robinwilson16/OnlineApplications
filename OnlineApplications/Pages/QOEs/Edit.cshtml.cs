using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineApplications.Data;
using OnlineApplications.Models;

namespace OnlineApplications.QOEs
{
    public class EditModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public EditModel(OnlineApplications.Data.ApplicationDbContext context)
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
           ViewData["ApplicationID"] = new SelectList(_context.Application, "ApplicationID", "Address1");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QualificationOnEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualificationOnEntryExists(QualificationOnEntry.QualificationOnEntryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QualificationOnEntryExists(int id)
        {
            return _context.QualificationOnEntry.Any(e => e.QualificationOnEntryID == id);
        }
    }
}
