using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace baskets.Models
{
    public class BasketRepository
    {
        string fileName;
        public BasketRepository(string FileName)
        {
            fileName = FileName;
        }

        public IEnumerable<Basket> GetBaskets()
        {
            var contents = File.ReadAllText(fileName).Split('\n').Skip(1);
            var csv = from line in contents
                      select line.Split(',');
            List<Basket> baskets = new List<Basket>();
            foreach(string line in contents)
            {
                if (!string.IsNullOrEmpty(line))
                {

                    var basket = new Basket();
                    var data = line.Split(',');
                    basket.TransactionNumber = new Guid(data[0]);

                    basket.NumberOfPassengers = string.IsNullOrEmpty(data[1]) ? 0 : Convert.ToInt32(data[1]);
                    basket.Domain = string.IsNullOrEmpty(data[2]) ? 0 : Convert.ToInt32(data[2]);
                    basket.AgentId = data[3];
                    if (Uri.IsWellFormedUriString(data[4], UriKind.Absolute))
                    {
                        basket.ReferrerUrl = new Uri(data[4]);
                    }
                    DateTime result = new DateTime();
                    if (DateTime.TryParse(data[5], out result))
                    {
                        basket.CreatedDateTime = result;
                    }
                    basket.UserId = data[6];
                    basket.SelectedCurrency = data[7];
                    basket.ReservationSystem = data[8];
                    baskets.Add(basket);
                }
            }
            
            return baskets;
        }
    }
}