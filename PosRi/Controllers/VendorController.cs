using PosRi.BusinessLogic.Managers;
using PosRi.Utils.Dtos;
using PosRi.Utils.Utils;
using System.Web.Http;

namespace PosRi.Controllers
{
    [RoutePrefix("api/vendor")]
    public class VendorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetVendors()
        {
            VendorManager vendorManager = new VendorManager();
            return Ok(vendorManager.GetVendors());
        }

        [HttpPost]
        public IHttpActionResult AddVendor(VendorDto vendor)
        {
            VendorManager vendorManager = new VendorManager();
            string message;
            if (vendorManager.IsValid(MethodTypes.Post, vendor, out message))
            {
                var newVendor = vendorManager.AddVendor(vendor, out message);
                if (newVendor != null)

                    return Ok(newVendor);
            }

            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateVendor(VendorDto vendor)
        {
            VendorManager vendorManager = new VendorManager();
            string message;
            if (vendorManager.IsValid(MethodTypes.Put, vendor, out message))
            {
                var vendorUpdated = vendorManager.UpdateVendor(vendor, out message);
                if (vendorUpdated != null)
                {
                    return Ok(vendorUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{vendorId}")]
        public IHttpActionResult DeleteVendor(int vendorId)
        {
            VendorManager vendorManager = new VendorManager();
            string message;
            var vendor = new VendorDto { Id = vendorId };
            if (vendorManager.IsValid(MethodTypes.Delete, vendor, out message))
            {
                if (vendorManager.DeleteVendor(vendor, out message))
                    return Ok();

            };
            return BadRequest(message);
        }

    }
}
