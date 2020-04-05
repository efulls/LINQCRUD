using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_CRUD_LINQ_SQL.Models
{
    public class PolicyInfo
    {
        public string ProductId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string InsuredTypeId { get; set; }
        public string InsuredTypeName { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PolicyNumber { get; set; }
        public QuoteInfo QuoteInfo { get; set; }
        public string PolicyStatus { get; set; }
        public string PaymentProcess { get; set; }
    }
}