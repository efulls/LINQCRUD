using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_API_CRUD_LINQ_SQL.Models;

namespace WEB_API_CRUD_LINQ_SQL.ViewModels
{
    public class PolicyRequestViewModel
    {
        public string SenderId { get; set; }
        public string QuoteId { get; set; }
        public DateTime RequestDate { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public PolicyInfo PolicyInfo { get; set; }
        public List<DataExtension> DataExtensions { get; set; }
    }
}