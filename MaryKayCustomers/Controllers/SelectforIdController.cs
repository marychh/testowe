using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaryKayCustomers.Controllers
{
    public class SelectforIdController : ApiController
    {
        private MaryKayCustomersEntities db = new MaryKayCustomersEntities();
        public IHttpActionResult GetSelectforId_Result(int id_customers)
        {
           //var result = db.SelectforId(id_customers);
            var result = db.Customers.FirstOrDefault(d => d.id_Customers == id_customers);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
