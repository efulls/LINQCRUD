﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_CRUD_LINQ_SQL.Models
{
    public class Address
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}