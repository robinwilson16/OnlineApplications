using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApplications.Models
{
    public class QualificationOnEntry
    {
        public int QualificationOnEntryID { get; set; }
        public int ApplicationID { get; set; }

        [Display(Name = "Qualification")]
        public int? SubjectID { get; set; }

        [Display(Name = "Subject (if not in list)")]
        [StringLength(100)]
        public string Subject { get; set; }

        [Display(Name = "Final Grade")]
        [StringLength(10)]
        public string ActualGrade { get; set; }

        [Display(Name = "Predicted Grade")]
        [StringLength(10)]
        public string PredictedGrade { get; set; }

        [Display(Name = "Date Awarded")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateAwarded { get; set; }

        public Application Application { get; set; }
    }
}
