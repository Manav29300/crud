using Microsoft.AspNetCore.Mvc;
using GeneralCRUD.Services;
using GeneralCRUD.Models;

namespace GeneralCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly PurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(PurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        // GET: api/PurchaseOrder
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return Ok(_purchaseOrderService.GetAllPurchaseOrders());
        }

        // GET: api/PurchaseOrder/{id}
        [HttpGet("{id}")]
        public ActionResult<PurchaseOrder> GetPurchaseOrderById(int id)
        {
            var purchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            return Ok(purchaseOrder);
        }

        // POST: api/PurchaseOrder
        [HttpPost]
        public ActionResult<PurchaseOrder> CreatePurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            var newPurchaseOrderId = _purchaseOrderService.InsertPurchaseOrder(purchaseOrder);
            return CreatedAtAction(nameof(GetPurchaseOrderById), new { id = newPurchaseOrderId }, purchaseOrder);
        }

        // PUT: api/PurchaseOrder/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePurchaseOrder(int id, [FromBody] PurchaseOrder purchaseOrder)
        {
            var existingPurchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            if (existingPurchaseOrder == null)
            {
                return NotFound();
            }

            purchaseOrder.po_id = id;
            _purchaseOrderService.UpdatePurchaseOrder(purchaseOrder);
            return NoContent();
        }

        // DELETE: api/PurchaseOrder/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePurchaseOrder(int id)
        {
            var existingPurchaseOrder = _purchaseOrderService.GetPurchaseOrderById(id);
            if (existingPurchaseOrder == null)
            {
                return NotFound();
            }

            _purchaseOrderService.DeletePurchaseOrder(id);
            return NoContent();
        }
    }
}
