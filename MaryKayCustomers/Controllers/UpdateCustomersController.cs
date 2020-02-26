using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaryKayCustomers.Controllers
{
    public class UpdateCustomersController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage POST(int id_customers, [FromBody] Customers customers)
        //public HttpResponseMessage Update_Customres(int id_customers)
        {
            try
            { 
            using (MaryKayCustomersEntities entities =new MaryKayCustomersEntities())
            {
                var entity = entities.Customers.FirstOrDefault(e => e.id_Customers == id_customers);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Klientka od danym identyfikatorze=" + id_customers.ToString() + " nie figuruje w bazie");
                }
                else
                {

                        entity.Name = customers.Name;
                        entity.Address = customers.Address;
                        entity.phone = customers.phone;
                        entity.husbentphone = customers.husbentphone;
                        entity.email = customers.email;
                        entity.dateofbirth = customers.dateofbirth;
                        entity.product = customers.product;
                        entity.buydate = customers.buydate;

                        entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
