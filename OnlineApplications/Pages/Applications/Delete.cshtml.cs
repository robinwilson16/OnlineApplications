﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineApplications.Data;
using OnlineApplications.Models;

namespace OnlineApplications.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public DeleteModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application Application { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = await _context.Application.FirstOrDefaultAsync(m => m.ApplicationID == id);

            if (Application == null)
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

            Application = await _context.Application.FindAsync(id);

            if (Application != null)
            {
                _context.Application.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
