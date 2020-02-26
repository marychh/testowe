using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaryKayCustomers.Controllers
{
    public class DeleteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Delete_Customres (int id_customers)
        {
            try
            {
                using (MaryKayCustomersEntities entities = new MaryKayCustomersEntities())
                {
                    var entity = entities.Customers.FirstOrDefault(d => d.id_Customers == id_customers);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Klientki o indetyfikatorze" + " " + id_customers.ToString() + "nie ma w bazie");
                    }
                    else
                    {
                        entities.Customers.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
