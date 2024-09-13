using GeneralCRUD.Models;
using GeneralCRUD;

namespace GeneralCRUD.Services
{
    public class PurchaseOrderService
    {
        private readonly DbExecutor _dbExecutor;

        public PurchaseOrderService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        // Retrieve all purchase orders
        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            string query = "SELECT * FROM purchase_orders";
            return _dbExecutor.ExecuteQuery<PurchaseOrder>(query);
        }

        // Retrieve a purchase order by its ID
        public PurchaseOrder GetPurchaseOrderById(int poId)
        {
            string query = "SELECT * FROM purchase_orders WHERE po_id = @poId";
            return _dbExecutor.ExecuteQuery<PurchaseOrder>(query, new { poId }).FirstOrDefault();
        }

        // Insert a new purchase order
        public int InsertPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            string query = @"INSERT INTO purchase_orders (vendor_id, po_number, order_date, status, total_amount)
                             VALUES (@vendor_id, @po_number, @order_date, @status, @total_amount)
                             RETURNING po_id;";
            return _dbExecutor.ExecuteScalar<int>(query, purchaseOrder);
        }

        // Update an existing purchase order
        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            string query = @"UPDATE purchase_orders SET vendor_id = @vendor_id, po_number = @po_number, order_date = @order_date, 
                             status = @status, total_amount = @total_amount WHERE po_id = @po_id";
            _dbExecutor.ExecuteNonQuery(query, purchaseOrder);
        }

        // Delete a purchase order
        public void DeletePurchaseOrder(int poId)
        {
            string query = "DELETE FROM purchase_orders WHERE po_id = @poId";
            _dbExecutor.ExecuteNonQuery(query, new { poId });
        }
    }
}
