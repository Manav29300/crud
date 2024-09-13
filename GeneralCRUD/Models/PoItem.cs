public class PoItem
{
    public int po_item_id { get; set; } // Primary key for po_items
    public int po_id { get; set; } // Foreign key linking to purchase_orders
    public int product_id { get; set; } // Foreign key linking to products
    public decimal quantity_ordered { get; set; } // Correct column for the quantity ordered
    
    public decimal unit_price { get; set; } // Price per unit of the product
    public decimal total_price { get; set; } // Total price (quantity_ordered * unit_price)
    public decimal received { get; set; } // New column representing received quantity
}
