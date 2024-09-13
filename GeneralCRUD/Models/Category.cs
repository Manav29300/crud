using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralCRUD.Models
{
    public class Category
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public string category_code { get; set; }
        public string description { get; set; }
        public int? parent_category_id { get; set; } // Nullable
        public string category_path { get; set; }    // Assuming it's stored as a string for simplicity
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }    // Nullable
        public bool is_deleted { get; set; }
    }

}
