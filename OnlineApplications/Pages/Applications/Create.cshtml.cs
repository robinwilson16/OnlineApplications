using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OnlineApplications.Data;
using OnlineApplications.Models;
using OnlineApplications.Shared;

namespace OnlineApplications.Applications
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
        public IList<SelectListData> QOEData { get; set; }
        public IList<SelectListData> GradeData { get; set; }

        public string CookieTest { get; set; }

        public async Task<PageResult> OnGetAsync(string academicYear)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(60);
            Response.Cookies.Append("CookieTest", "Testing", option);

            string applicationData = Request.Cookies["ApplicationData"];
            byte[] decodedBytes = Convert.FromBase64String(applicationData);
            string decodedString = ASCIIEncoding.ASCII.GetString(decodedBytes);
            var jApplicationData = JObject.Parse(decodedString);
            CookieTest = decodedString;
            //CookieTest = jApplicationData.GetValue("Application.Title").ToString();

            //Application = new Application
            //{
            //    Forename = "Robin"
            //};

            Application = CookieFunctions.GetApplicationCookieValues(Request);

            string selectListDomain = null;

            selectListDomain = "TITLE";
            TitleData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["TitleID"] = new SelectList(TitleData, "Code", "Description");

            selectListDomain = "GENDER";
            GenderData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["GenderID"] = new SelectList(GenderData, "Code", "Description");

            selectListDomain = "VISA";
            VisaData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["VisaTypeID"] = new SelectList(VisaData, "Code", "Description");

            selectListDomain = "SCHOOL";
            SchoolData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["SchoolID"] = new SelectList(SchoolData, "Code", "Description");

            selectListDomain = "ETHNIC_GROUP";
            EthnicGroupData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["EthnicGroupID"] = new SelectList(EthnicGroupData, "Code", "Description");

            selectListDomain = "DISABILITY_CATEGORY";
            DisabilityCategoryData = await _context.SelectListData
                .FromSqlInterpolated($"EXEC SPR_OLA_SelectListData @Domain={selectListDomain}")
                .AsNoTracking()
                .ToListAsync();

            ViewData["DisabilityCategoryID"] = new SelectList(DisabilityCategoryData, "Code", "Description");

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
        public Application Application { get; set; }

        public List<QualificationOnEntry> QualificationOnEntry = new List<QualificationOnEntry>
        {
            new QualificationOnEntry {
                ApplicationID = 0,
                SubjectID = null,
                Subject = null,
                ActualGrade = null,
                PredictedGrade = null,
                DateAwarded = null
            }
        };

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
