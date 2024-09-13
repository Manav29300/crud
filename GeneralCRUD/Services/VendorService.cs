using GeneralCRUD;
namespace GeneralCRUD.Services
{
    public class VendorService
    {
        private readonly DbExecutor _dbExecutor;

        public VendorService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        public List<Vendor> GetAllVendors()
        {
            string query = "SELECT * FROM vendors";
            return _dbExecutor.ExecuteQuery<Vendor>(query);
        }

        public Vendor GetVendorById(int vendorId)
        {
            string query = "SELECT * FROM vendors WHERE vendor_id = @vendorId";
            return _dbExecutor.ExecuteQuery<Vendor>(query, new { vendorId }).FirstOrDefault();
        }

        public int InsertVendor(Vendor vendor)
        {
            string query = @"INSERT INTO vendors (vendor_name, contact_person, phone_number, email, address, created_at)
                         VALUES (@vendor_name, @contact_person, @phone_number, @email, @address, @created_at)
                         RETURNING vendor_id;";
            return _dbExecutor.ExecuteScalar<int>(query, vendor);
        }

        public void UpdateVendor(Vendor vendor)
        {
            string query = @"UPDATE vendors SET vendor_name = @vendor_name, contact_person = @contact_person, 
                         phone_number = @phone_number, email = @email, address = @address WHERE vendor_id = @vendor_id";
            _dbExecutor.ExecuteNonQuery(query, vendor);
        }

        public void DeleteVendor(int vendorId)
        {
            string query = "DELETE FROM vendors WHERE vendor_id = @vendorId";
            _dbExecutor.ExecuteNonQuery(query, new { vendorId });
        }
    }
}
