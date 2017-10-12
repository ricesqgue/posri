using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PosRi.BusinessLogic.Dtos;
using PosRi.BusinessLogic.Managers;
using PosRi.BusinessLogic.Utils;

namespace PosRi.Controllers
{
    public class BrandController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetBrands()
        {
            BrandManager brandManager = new BrandManager();
            return Ok(brandManager.GetBrands());
        }

        [HttpPost]
        public IHttpActionResult AddBrand(BrandDto brand)
        {
            BrandManager brandManager = new BrandManager();
            string message;
            if (brandManager.IsValid(MethodTypes.Post, brand, out message))
            {
                var newBrand = brandManager.AddBrand(brand, out message);
                if (newBrand != null)

                    return Ok(newBrand);
            }

            return BadRequest(message);

        }

        [HttpPut]
        public IHttpActionResult UpdateBrand(BrandDto brand)
        {
            BrandManager brandManager = new BrandManager();
            string message;
            if (brandManager.IsValid(MethodTypes.Put, brand, out message))
            {
                var brandUpdated = brandManager.UpdateBrand(brand, out message);
                if (brandUpdated != null)
                {
                    return Ok(brandUpdated);
                }
            }

            return BadRequest(message);
        }

        [HttpDelete]
        [Route("{brandId}")]
        public IHttpActionResult DeleteBrand(int brandId)
        {
            BrandManager brandManager = new BrandManager();
            string message;
            var brand = new BrandDto { Id = brandId };
            if (brandManager.IsValid(MethodTypes.Delete, brand, out message))
            {
                if (brandManager.DeleteBrand(brand, out message))
                    return Ok();

            };
            return BadRequest(message);
        }
    }
}
