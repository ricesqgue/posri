using PosRi.BusinessLogic.Managers;
using PosRi.Utils.Dtos;
using PosRi.Utils.Utils;
using System.Web.Http;

namespace PosRi.Controllers
{
    [RoutePrefix("api/cashregister")]
    public class CashRegisterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCashRegisters()
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            return Ok(cashRegisterManager.GetCashRegisters());
        }

        [HttpPost]
        public IHttpActionResult AddCashRegister(CashRegisterDto cashRegister)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;
            if (cashRegisterManager.IsValid(MethodTypes.Post, cashRegister, out message))
            {
                var newCashRegister = cashRegisterManager.AddCashRegister(cashRegister, out message);
                if (newCashRegister != null)

                    return Ok(newCashRegister);
            }

            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateCashRegister(CashRegisterDto cashRegister)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;
            if (cashRegisterManager.IsValid(MethodTypes.Put, cashRegister, out message))
            {
                var cashRegisterUpdated = cashRegisterManager.UpdateCashRegister(cashRegister, out message);
                if (cashRegisterUpdated != null)
                {
                    return Ok(cashRegisterUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{cashRegisterId}")]
        public IHttpActionResult DeleteCashRegister(int cashRegisterId)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;
            var cashRegister = new CashRegisterDto { Id = cashRegisterId };
            if (cashRegisterManager.IsValid(MethodTypes.Delete, cashRegister, out message))
            {
                if (cashRegisterManager.DeleteCashRegister(cashRegister, out message))
                    return Ok();

            };
            return BadRequest(message);
        }

        [HttpGet]
        [Route("cashfound/{cashRegisterId}")]
        public IHttpActionResult GetCashFounds(int cashRegisterId)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;

            var cashFounds = cashRegisterManager.GetCashFounds(cashRegisterId, out message);
            if (cashFounds != null)
                return Ok(cashFounds);

            return BadRequest(message);
        }

        [HttpGet]
        [Route("cashfound/current/{cashRegisterId}")]
        public IHttpActionResult GetCashFound(int cashRegisterId)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;

            var cashFound = cashRegisterManager.GetCashFound(cashRegisterId, out message);
            if (cashFound != null)
                return Ok(cashFound);

            return BadRequest(message);
        }

        [HttpPost]
        [Route("cashfound")]
        public IHttpActionResult SaveCashFound(CashFoundDto cashFound)
        {
            CashRegisterManager cashRegisterManager = new CashRegisterManager();
            string message;

            var newCashFound = cashRegisterManager.SaveCashFound(cashFound, out message);
            if (newCashFound != null)
                return Ok(cashFound);

            return BadRequest(message);

        }
    }
}
