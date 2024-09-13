using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralCRUD.Models
{
    public class Product
    {
        public int product_id { get; set; } // Maps to product_id column
        public string product_name { get; set; } // Maps to product_name column
        public string product_code { get; set; } // Maps to product_code column
        public string description { get; set; } // Maps to description column
        public string category { get; set; } // Maps to category column
        public string unit_of_measure { get; set; } // Maps to unit_of_measure column
        public decimal cost { get; set; } // Maps to cost column
        public decimal price { get; set; } // Maps to price column
        public DateTime created_at { get; set; } // Maps to created_at column
        public string created_by { get; set; } // Maps to created_by column
        public string updated_by { get; set; } // Maps to updated_by column
        public DateTime? updated_at { get; set; } // Maps to updated_at column (nullable)
        public bool is_deleted { get; set; } // Maps to is_deleted column (boolean)
        public string category_path { get; set; } // Maps to category_path column
        public string metadata { get; set; } // Maps to metadata column (could be JSON or string)
        public int? barcode_system_id { get; set; } // Maps to barcode_system_id column (nullable integer)
        public string barcode { get; set; } // Maps to barcode column
    }


}
