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
    public class CreateModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public CreateModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SelectListData> QOEData { get; set; }
        public IList<SelectListData> GradeData { get; set; }

        public async Task<PageResult> OnGetAsync(string academicYear)
        {
            string selectListDomain = null;

            selectListDomain = "QOE";
            QOEData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["QOEID"] = new SelectList(QOEData, "Code", "Description");

            selectListDomain = "GRADE";
            GradeData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["GradeID"] = new SelectList(GradeData, "Code", "Description");

            return Page();
        }

        [BindProperty]
        public QualificationOnEntry QualificationOnEntry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.QualificationOnEntry.Add(QualificationOnEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
