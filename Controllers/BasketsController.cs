using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using baskets.Models;
namespace baskets.Controllers
{
    public class BasketsController : ApiController
    {
        private BasketRepository basketRepository;
        public BasketsController()
        {
            basketRepository = new BasketRepository(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/baskets.csv"));
        }

        
        [HttpGet]
        [Route("Baskets")]
        public IEnumerable<Basket> GetBaskets(int? Domain=null)
        {
            return Domain==null? basketRepository.GetBaskets():basketRepository.GetBaskets().Where(x=>x.Domain==Domain);
        }

        [HttpGet]
        [Route("Basket/{TransactionNumber}")]
        public Basket GetBasket(Guid TransactionNumber)
        {
            return basketRepository.GetBaskets().Where(x => x.TransactionNumber == TransactionNumber).FirstOrDefault();
        }
    }
}
