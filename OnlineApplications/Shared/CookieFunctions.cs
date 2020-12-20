using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using OnlineApplications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplications.Shared
{
    public class CookieFunctions
    {
        public static Application GetApplicationCookieValues(HttpRequest request)
        {
            //Get cookie
            string applicationData = request.Cookies["ApplicationData"];
            byte[] decodedBytes = Convert.FromBase64String(applicationData);
            string decodedString = ASCIIEncoding.ASCII.GetString(decodedBytes);
            var jApplicationData = JObject.Parse(decodedString);

            Application application = new Application
            {
                Title = jApplicationData.GetValue("Application.Title")?.ToString() ?? null,
                Forename = jApplicationData.GetValue("Application.Forename")?.ToString() ?? null,
                Surname = jApplicationData.GetValue("Application.Surname")?.ToString() ?? null,
                DOB = DateTime.Parse(jApplicationData.GetValue("Application.DOB")?.ToString() ?? null),
                Gender = jApplicationData.GetValue("Application.Gender")?.ToString() ?? null,
                MobilePhone = jApplicationData.GetValue("Application.MobilePhone")?.ToString() ?? null,
                HomePhone = jApplicationData.GetValue("Application.HomePhone")?.ToString() ?? null,
                Email = jApplicationData.GetValue("Application.Email")?.ToString() ?? null
            };

            return application;
        }
    }
}
