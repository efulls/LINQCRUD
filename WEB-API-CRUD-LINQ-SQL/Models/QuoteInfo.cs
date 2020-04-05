using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_CRUD_LINQ_SQL.Models
{
    public class QuoteInfo
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CoverageConditionsInd { get; set; }
        public DateTime QuoteRequestDate { get; set; }
        public DateTime ValidUntilDate { get; set; }
    }
}