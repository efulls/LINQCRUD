using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API_CRUD.Controllers.Api
{
    public class NlogController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Exception ex = new Exception();

        [Route("~/Log/CreateLog")]
        [HttpGet]
        public IHttpActionResult InsuranceProduct()
        {

            string one = "this is first condition";
            string second = "this is second condition";

            logger.ErrorException("Error occured in"+ one +" Home controller Index Error"+ second, ex);
                logger.InfoException("Error occured in Home controller Index Info", ex);
                logger.DebugException("Error occured in Home controller Index Debug", ex);
                logger.FatalException("Error occured in Home controller Index Fatal", ex);

            return Ok("Log Oke..!!");
        }

    }
}
