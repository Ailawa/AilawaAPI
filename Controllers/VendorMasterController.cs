using System.Collections.Generic;
using AilawaAPI.Data.models;
using AilawaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AilawaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorMasterController : ControllerBase
    {
        private readonly IVendorDetails vendorDetails;
        public VendorMasterController(IVendorDetails vendorDetails)
        {
            this.vendorDetails = vendorDetails;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<VendorMaster>> GetVendorDetails()
        {
            return Ok(vendorDetails.GetVendorDetails());
        }
    }
}