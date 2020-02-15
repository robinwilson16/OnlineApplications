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

namespace OnlineApplications
{
    public class CreateModel : PageModel
    {
        private readonly OnlineApplications.Data.ApplicationDbContext _context;

        public CreateModel(OnlineApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SelectListData> TitleData { get; set; }
        public IList<SelectListData> GenderData { get; set; }
        public IList<SelectListData> VisaData { get; set; }
        public IList<SelectListData> SchoolData { get; set; }
        public IList<SelectListData> EthnicGroupData { get; set; }
        public IList<SelectListData> DisabilityCategoryData { get; set; }

        public async Task<PageResult> OnGetAsync(string system, string systemILP, string academicYear)
        {
            string selectListDomain = null;

            selectListDomain = "TITLE";
            TitleData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["TitleID"] = new SelectList(TitleData, "Code", "Description");

            selectListDomain = "GENDER";
            GenderData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["GenderID"] = new SelectList(GenderData, "Code", "Description");

            selectListDomain = "VISA";
            VisaData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["VisaTypeID"] = new SelectList(VisaData, "Code", "Description");

            selectListDomain = "SCHOOL";
            SchoolData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["SchoolID"] = new SelectList(SchoolData, "Code", "Description");

            selectListDomain = "ETHNIC_GROUP";
            EthnicGroupData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["EthnicGroupID"] = new SelectList(EthnicGroupData, "Code", "Description");

            selectListDomain = "DISABILITY_CATEGORY";
            DisabilityCategoryData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .ToListAsync();

            ViewData["DisabilityCategoryID"] = new SelectList(DisabilityCategoryData, "Code", "Description");

            return Page();
        }

        [BindProperty]
        public Application Application { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Application.Add(Application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
