using PosRi.BusinessLogic.Managers;
using PosRi.Utils.Dtos;
using PosRi.Utils.Utils;
using System.Web.Http;

namespace PosRi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            CustomerManager customerManager = new CustomerManager();
            return Ok(customerManager.GetCustomers());
        }

        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto customer)
        {
            CustomerManager customerManager = new CustomerManager();
            string message;
            if (customerManager.IsValid(MethodTypes.Post, customer, out message))
            {
                var newCustomer = customerManager.AddCustomer(customer, out message);
                if (newCustomer != null)

                    return Ok(newCustomer);
            }

            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customer)
        {
            CustomerManager customerManager = new CustomerManager();
            string message;
            if (customerManager.IsValid(MethodTypes.Put, customer, out message))
            {
                var customerUpdated = customerManager.UpdateCustomer(customer, out message);
                if (customerUpdated != null)
                {
                    return Ok(customerUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{customerId}")]
        public IHttpActionResult DeleteCustomer(int customerId)
        {
            CustomerManager customerManager = new CustomerManager();
            string message;
            var customer = new CustomerDto { Id = customerId };
            if (customerManager.IsValid(MethodTypes.Delete, customer, out message))
            {
                if (customerManager.DeleteCustomer(customer, out message))
                    return Ok();

            };
            return BadRequest(message);
        }
    }
}
