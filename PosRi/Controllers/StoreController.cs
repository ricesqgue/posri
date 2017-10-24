using PosRi.BusinessLogic.Managers;
using PosRi.Utils.Dtos;
using PosRi.Utils.Utils;
using System.Web.Http;

namespace PosRi.Controllers
{
    [RoutePrefix("api/store")]
    public class StoreController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetStores()
        {
            StoreManager storeManager = new StoreManager();
            return Ok(storeManager.GetStores());
        }

        [HttpPost]
        public IHttpActionResult AddStore(StoreDto store)
        {
            StoreManager storeManager = new StoreManager();
            string message;
            if (storeManager.IsValid(MethodTypes.Post, store, out message))
            {
                var newStore = storeManager.AddStore(store, out message);
                if (newStore != null)

                    return Ok(newStore);
            }

            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateStore(StoreDto store)
        {
            StoreManager storeManager = new StoreManager();
            string message;
            if (storeManager.IsValid(MethodTypes.Put, store, out message))
            {
                var storeUpdated = storeManager.UpdateStore(store, out message);
                if (storeUpdated != null)
                {
                    return Ok(storeUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{storeId}")]
        public IHttpActionResult DeleteStore(int storeId)
        {
            StoreManager storeManager = new StoreManager();
            string message;
            var store = new StoreDto { Id = storeId };
            if (storeManager.IsValid(MethodTypes.Delete, store, out message))
            {
                if (storeManager.DeleteStore(store, out message))
                    return Ok();

            };
            return BadRequest(message);
        }
    }
}
