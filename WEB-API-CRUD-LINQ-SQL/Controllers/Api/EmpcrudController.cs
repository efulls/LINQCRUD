using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API_CRUD_LINQ_SQL.Controllers.Api
{
    public class EmpcrudController : ApiController
    {
        LinqSqlClassesDataContext dc = new LinqSqlClassesDataContext();
        public IHttpActionResult Getemprecords()
        {
            var emprecords = dc.newemps.ToList();
            return Ok(emprecords);
        }
    }
}
