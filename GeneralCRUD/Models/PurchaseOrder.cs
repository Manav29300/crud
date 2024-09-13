namespace GeneralCRUD.Models
{
    public class PurchaseOrder
    {
        public int po_id { get; set; } // Primary Key
        public int vendor_id { get; set; } // Foreign Key to Vendors
        public string po_number { get; set; } // Purchase Order Number
        public DateTime order_date { get; set; } // Order Date
        public string status { get; set; } // Order Status (e.g., Pending, Received, Cancelled)
        public decimal total_amount { get; set; } // Total Amount of the Purchase Order
        public DateTime created_at { get; set; } // Date and Time of Creation
    }
}
