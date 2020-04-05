using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_CRUD_LINQ_SQL.Models
{
    public class ContactInfo
    {
        public List<NameInfo> NameInfos { get; set; }
        public List<PhoneInfo> PhoneInfos { get; set; }
        public List<EmailInfo> EmailInfos { get; set; }
        public Address Address { get; set; }
    }
}