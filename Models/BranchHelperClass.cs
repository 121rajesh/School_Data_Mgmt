using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDataMgtm.Models
{
    public class BranchHelperClass
    {
        public string SchoolName { get; set; }
        public string Branch { get; set; }
        public string Principal { get; set; }
        public System.DateTime CreationDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}