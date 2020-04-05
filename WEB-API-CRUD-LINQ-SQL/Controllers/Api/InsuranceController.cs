using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_CRUD_LINQ_SQL.Models;
using WEB_API_CRUD_LINQ_SQL.ViewModels;

namespace WEB_API_CRUD_LINQ_SQL.Controllers.Api
{
    public class InsuranceController : ApiController
    {
        LinqSqlClassesDataContext dc = new LinqSqlClassesDataContext();

        [Route("~/Insurance/Insert")]
        [HttpPost]
        public IHttpActionResult InsureancePurchase(PolicyRequestViewModel ip)
        {

            TrxInsurancePurchase TrxIp = new TrxInsurancePurchase()
            {

                Id = Guid.NewGuid().ToString("N"),
                SenderId = ip.SenderId,
                QuoteId = ip.QuoteId,

                //Name info
                PhoneNumber = ip.ContactInfo.PhoneInfos[0].PhoneNumber,
                MobileNumber = ip.ContactInfo.PhoneInfos[1].PhoneNumber,
                Email = ip.ContactInfo.EmailInfos[0].EmailAddr,
                Address1 = ip.ContactInfo.Address.Addr1,
                Address2 = ip.ContactInfo.Address.Addr2,
                Address3 = ip.ContactInfo.Address.Addr3,
                City = ip.ContactInfo.Address.City,
                StateProv = ip.ContactInfo.Address.StateProv,
                PostalCode = ip.ContactInfo.Address.PostalCode,
                Country = ip.ContactInfo.Address.Country,

                //Policy info
                ProductId = ip.PolicyInfo.ProductId,
                EffectiveDate = ip.PolicyInfo.EffectiveDate,
                ExpirationDate = ip.PolicyInfo.ExpirationDate,
                DestinationId = ip.PolicyInfo.DestinationId,
                DestionationName = ip.PolicyInfo.DestinationName,
                InsuredTypeId = ip.PolicyInfo.InsuredTypeId,
                InsuredTypeName = ip.PolicyInfo.InsuredTypeName,
                PlanId = ip.PolicyInfo.PlanId,
                PlanName = ip.PolicyInfo.PlanName,
                
                //Data Extension
                DepartureCity = ip.DataExtensions[0].DataItemValue,
                ArrivalCity = ip.DataExtensions[1].DataItemValue,
                PaymentMethod = ip.DataExtensions[2].DataItemValue,
                BookingReference = ip.DataExtensions[3].DataItemValue,
            };


            dc.TrxInsurancePurchases.InsertOnSubmit(TrxIp);
            //dc.SubmitChanges();

            var i = 0;
            var fadd = from nameinf in ip.ContactInfo.NameInfos
                       select new TrxInsurancePax
                       {
                           Id = Guid.NewGuid().ToString("N"),
                           TrxInsurancePurchaseId = TrxIp.Id,
                           Surname = nameinf.Surname,
                           GivenName = nameinf.GivenName,
                           TitlePrefix = nameinf.TitlePrefix,
                           BirthDt = nameinf.BirthDt,
                           IdNumberTypeCd = nameinf.IdNumber,
                           TitleRelationshipDesc = nameinf.TitleRelationshipDesc,
                           PaxNumber = i++
                       };

            dc.TrxInsurancePaxes.InsertAllOnSubmit(fadd);
            dc.SubmitChanges();

            return Ok(TrxIp.Id);

        }

        [Route("~/Insurance/PurchaseById")]
        [HttpPost]
        public IHttpActionResult ShowPurchaseById(ByPurchaseId rq)
        {
            var purchase = (from x in dc.TrxInsurancePurchases where x.Id == rq.PurchaseId select x).FirstOrDefault();
            return Ok(purchase);
        }
    }
}
