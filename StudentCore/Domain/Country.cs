using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Common;

namespace StudentCore.Domain
{
     [Serializable()]
    public class Country
    {
        [DBField("ID")]
        public string CountryCode { get; set; }

        [DBField("Name")]
        public string CountryName { get; set; }

        [DBField("Is_Active")]
        public string IsActive { get; set; }  
    }
}
