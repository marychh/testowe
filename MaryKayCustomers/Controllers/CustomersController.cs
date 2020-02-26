using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaryKayCustomers.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customers> Get()
        {
            using (MaryKayCustomersEntities number = new MaryKayCustomersEntities())
            {
                return number.Customers.ToList();
            }
        }
    }
}
