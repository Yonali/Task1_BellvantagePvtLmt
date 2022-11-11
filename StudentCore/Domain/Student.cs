using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Common;

namespace StudentCore.Domain
{
    [Serializable()]
    public class Student
    {
        [DBField("ID")]
        public int StudentId { get; set; }

        [DBField("First_Name")]
        public string FirstName { get; set; }

        [DBField("Last_Name")]
        public string LastName { get; set; }

        [DBField("Email")]
        public string Email { get; set; }
        
        [DBField("Country_ID")]
        public string CountryCode { get; set; }

        [DBField("Gender")]
        public string Gender { get; set; }

        public Country country { get; set; }
    }
}
