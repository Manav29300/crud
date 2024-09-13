using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralCRUD.Models
{
    public class Customer
    {
        public int customer_id { get; set; } // Maps to customer_id in the database
        public string first_name { get; set; } // Maps to first_name in the database
        public string last_name { get; set; } // Maps to last_name in the database
        public string email { get; set; } // Maps to email in the database
        public string phone_number { get; set; } // Maps to phone_number in the database
        public string billing_address { get; set; } // Maps to billing_address in the database
        public string shipping_address { get; set; } // Maps to shipping_address in the database
        public DateTime created_at { get; set; } // Maps to created_at in the database
        public bool is_active { get; set; } // Maps to is_active in the database
    }

}
