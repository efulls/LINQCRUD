using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_CRUD_LINQ_SQL.Models;

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

        public IHttpActionResult Getemprecords(int id)
        {
            var displayempdata = (from x in dc.newemps where x.Empid == id select x).FirstOrDefault();
            return Ok(displayempdata);
        }

        [HttpPost]
        public IHttpActionResult Insertemp(newemp ne)
        {
            dc.newemps.InsertOnSubmit(ne);
            dc.SubmitChanges();
            return Ok();

        }

        //Another methode single insert method
        [Route("~/Employee/NewAdd")]
        [HttpPost]
        public IHttpActionResult InsertempNew(newemp ne)
        {

            newemp Emplo = new newemp();
            Emplo.Empname = ne.Empname;
            Emplo.Email = ne.Email;
            Emplo.Location = ne.Location;

            dc.newemps.InsertOnSubmit(Emplo);
            dc.SubmitChanges();
            return Ok();

        }

        //Multiple insert method
        [Route("~/Employee/NewMultiple")]
        [HttpPost]
        public IHttpActionResult InsertempMultiple(IEnumerable<newemp> ne)
        {
            var fadd = from field in ne
                       select new newemp
                       {
                           Empname = field.Empname,
                           Email = field.Email,
                           Location = field.Location
                       };
            
            dc.newemps.InsertAllOnSubmit(fadd);
            dc.SubmitChanges();
            return Ok();

        }

        public IHttpActionResult Put(EmpClass ec)
        {
            var updateemp = (from x in dc.newemps where x.Empid == ec.Empid select x).FirstOrDefault();
            if(updateemp != null)
            {
                updateemp.Empid = ec.Empid;
                updateemp.Empname = ec.Empname;
                updateemp.Email = ec.Email;
                updateemp.Location = ec.Location;
                dc.SubmitChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var deleteemp = (from x in dc.newemps where x.Empid == id select x).FirstOrDefault();
            dc.newemps.DeleteOnSubmit(deleteemp);
            dc.SubmitChanges();
            return Ok();
        }
    }
}
