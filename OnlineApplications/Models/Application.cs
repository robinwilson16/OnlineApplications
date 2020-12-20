using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApplications.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }

        [StringLength(6)]
        [Required]
        public string Title { get; set; }

        [StringLength(50)]
        [Required]
        public string Forename { get; set; }

        [StringLength(40)]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [StringLength(1)]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string MobilePhone { get; set; }

        [Display(Name = "Home Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string HomePhone { get; set; }

        [Display(Name = "Email")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool PreferLetter { get; set; }

        [Display(Name = "First Line of Address")]
        [StringLength(100)]
        [Required]
        public string Address1 { get; set; }

        [Display(Name = "Second Line")]
        [Required]
        [StringLength(100)]
        public string Address2 { get; set; }

        [Display(Name = "Third Line")]
        [StringLength(100)]
        public string Address3 { get; set; }

        [Display(Name = "Forth Line")]
        [StringLength(100)]
        public string Address4 { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public string PostcodeOut { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public string PostcodeIn { get; set; }

        public bool VisaRequired { get; set; }
        public bool VisaHeld { get; set; }

        [Display(Name = "If you have answered 'yes' to any of the above questions, what type of visa do you currently hold or intend to apply for?")]
        public int? VisaType { get; set; }

        [Display(Name = "Where did you previously study?")]
        public int? SchoolID { get; set; }

        [Display(Name = "What is your ethnicity?")]
        public int? EthnicGroupID { get; set; }

        [Display(Name = "Do you have any Disabilities or Learning Difficulties?")]
        public int? DisabilityCategoryID { get; set; }

        [Display(Name = "If you need additional support at interview because of your learning difficulty or disability please tick this box. A member of our Additional Learning Support team will contact you to discuss your needs.")]
        public bool AdditionalSupportRequiredAtInterview { get; set; }
    }
}
