using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDataMgtm.Models
{
    public class Response
    {
        public string Status { get; set; }
        public Exception Error { get; set; }
        public dynamic Data { get; set; }
    }
}