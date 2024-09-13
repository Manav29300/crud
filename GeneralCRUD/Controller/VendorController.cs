using GeneralCRUD.Models;
using GeneralCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly VendorService _vendorService;

        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public IActionResult GetVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            return Ok(vendors);
        }

        [HttpPost]
        public IActionResult CreateVendor([FromBody] Vendor vendor)
        {
            if (vendor == null)
                return BadRequest("Vendor data is missing.");

            _vendorService.InsertVendor(vendor);
            return CreatedAtAction(nameof(GetVendors), new { id = vendor.vendor_id }, vendor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendor(int id, [FromBody] Vendor vendor)
        {
            var existingVendor = _vendorService.GetVendorById(id);
            if (existingVendor == null) return NotFound();

            _vendorService.UpdateVendor(vendor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVendor([FromRoute] int id)
        {
            var existingVendor = _vendorService.GetVendorById(id);
            if (existingVendor == null) return NotFound();

            _vendorService.DeleteVendor(id);
            return NoContent();
        }
    }
}
