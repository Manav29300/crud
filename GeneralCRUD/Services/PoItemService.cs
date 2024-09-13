using GeneralCRUD.Models;
using GeneralCRUD;

namespace GeneralCRUD.Services
{
    public class PoItemService
    {
        private readonly DbExecutor _dbExecutor;

        public PoItemService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        // Get all PO items
        public List<PoItem> GetAllPoItems()
        {
            string query = "SELECT * FROM po_items";
            return _dbExecutor.ExecuteQuery<PoItem>(query);
        }

        // Get PO item by ID
        public PoItem GetPoItemById(int po_item_id)
        {
            string query = "SELECT * FROM po_items WHERE po_item_id = @po_item_id";
            return _dbExecutor.ExecuteQuery<PoItem>(query, new { po_item_id }).FirstOrDefault();
        }

        // Insert a new PO item
        public int InsertPoItem(PoItem poItem)
        {
            string query = @"INSERT INTO po_items (po_id, product_id, quantity_ordered, received, unit_price, total_price)
                             VALUES (@po_id, @product_id, @quantity_ordered, @received, @unit_price, @total_price)
                             RETURNING po_item_id;";
            return _dbExecutor.ExecuteScalar<int>(query, poItem);
        }

        // Update an existing PO item
        public void UpdatePoItem(PoItem poItem)
        {
            string query = @"UPDATE po_items SET po_id = @po_id, product_id = @product_id, 
                             quantity_ordered = @quantity_ordered, received = @received, 
                             unit_price = @unit_price, total_price = @total_price 
                             WHERE po_item_id = @po_item_id";
            _dbExecutor.ExecuteNonQuery(query, poItem);
        }

        // Delete PO item
        public void DeletePoItem(int po_item_id)
        {
            string query = "DELETE FROM po_items WHERE po_item_id = @po_item_id";
            _dbExecutor.ExecuteNonQuery(query, new { po_item_id });
        }
    }
}
