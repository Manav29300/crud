using GeneralCRUD.Models;
using GeneralCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarrantyConfigurationController : ControllerBase
    {
        private readonly WarrantyConfigurationService _warrantyConfigurationService;

        public WarrantyConfigurationController(WarrantyConfigurationService warrantyConfigurationService)
        {
            _warrantyConfigurationService = warrantyConfigurationService;
        }

        // GET: api/warrantyconfiguration
        [HttpGet]
        public ActionResult<List<WarrantyConfiguration>> GetAllWarrantyConfigurations()
        {
            return Ok(_warrantyConfigurationService.GetAllWarrantyConfigurations());
        }

        // GET: api/warrantyconfiguration/{id}
        [HttpGet("{id}")]
        public ActionResult<WarrantyConfiguration> GetWarrantyConfigurationById(int id)
        {
            var warrantyConfig = _warrantyConfigurationService.GetWarrantyConfigurationById(id);
            if (warrantyConfig == null)
                return NotFound();
            return Ok(warrantyConfig);
        }

        // POST: api/warrantyconfiguration
        [HttpPost]
        public ActionResult<int> InsertWarrantyConfiguration([FromBody] WarrantyConfiguration warrantyConfig)
        {
            var newWarrantyConfigId = _warrantyConfigurationService.InsertWarrantyConfiguration(warrantyConfig);
            return CreatedAtAction(nameof(GetWarrantyConfigurationById), new { id = newWarrantyConfigId }, newWarrantyConfigId);
        }

        // PUT: api/warrantyconfiguration/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateWarrantyConfiguration(int id, [FromBody] WarrantyConfiguration warrantyConfig)
        {
            var existingConfig = _warrantyConfigurationService.GetWarrantyConfigurationById(id);
            if (existingConfig == null)
                return NotFound();

            warrantyConfig.WarrantyConfigId = id;
            _warrantyConfigurationService.UpdateWarrantyConfiguration(warrantyConfig);
            return NoContent();
        }

        // DELETE: api/warrantyconfiguration/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWarrantyConfiguration(int id)
        {
            var existingConfig = _warrantyConfigurationService.GetWarrantyConfigurationById(id);
            if (existingConfig == null)
                return NotFound();

            _warrantyConfigurationService.DeleteWarrantyConfiguration(id);
            return NoContent();
        }
    }
}
