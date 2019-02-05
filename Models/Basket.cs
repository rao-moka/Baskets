using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baskets.Models
{
    public class Basket
    {
        public Guid TransactionNumber { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Domain { get; set; }
        public string AgentId { get; set; }
        public Uri ReferrerUrl { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string UserId { get; set; }
        public string SelectedCurrency { get; set; }
        public string ReservationSystem { get; set; }


    }
}