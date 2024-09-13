using Microsoft.AspNetCore.Mvc;
using GeneralCRUD.Models;
using GeneralCRUD.Services;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoItemController : ControllerBase
    {
        private readonly PoItemService _poItemService;

        public PoItemController(PoItemService poItemService)
        {
            _poItemService = poItemService;
        }

        [HttpGet]
        public IActionResult GetAllPoItems()
        {
            var poItems = _poItemService.GetAllPoItems();
            return Ok(poItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetPoItemById(int id)
        {
            var poItem = _poItemService.GetPoItemById(id);
            if (poItem == null)
            {
                return NotFound();
            }
            return Ok(poItem);
        }

        [HttpPost]
        public IActionResult CreatePoItem([FromBody] PoItem poItem)
        {
            var newId = _poItemService.InsertPoItem(poItem);
            return CreatedAtAction(nameof(GetPoItemById), new { id = newId }, poItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePoItem(int id, [FromBody] PoItem poItem)
        {
            var existingItem = _poItemService.GetPoItemById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            poItem.po_item_id = id;
            _poItemService.UpdatePoItem(poItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePoItem(int id)
        {
            var existingItem = _poItemService.GetPoItemById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _poItemService.DeletePoItem(id);
            return NoContent();
        }
    }
}
