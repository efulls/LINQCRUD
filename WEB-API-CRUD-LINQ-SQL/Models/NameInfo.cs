using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_CRUD_LINQ_SQL.Models
{
    public class NameInfo
    {
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string TitlePrefix { get; set; }
        public DateTime BirthDt { get; set; }
        public string IdNumberTypeCd { get; set; }
        public string IdNumber { get; set; }
        public string TitleRelationshipDesc { get; set; }
    }
}