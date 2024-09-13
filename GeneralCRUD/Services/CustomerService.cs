using GeneralCRUD.Models;
using GeneralCRUD;
namespace GeneralCRUD.Services
{
    public class CustomerService
    {
        private readonly DbExecutor _dbExecutor;

        public CustomerService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        public List<Customer> GetAllCustomers()
        {
            string query = "SELECT * FROM customers";
            return _dbExecutor.ExecuteQuery<Customer>(query);
        }

        public Customer GetCustomerById(int customerId)
        {
            string query = "SELECT * FROM customers WHERE customer_id = @customerId";
            return _dbExecutor.ExecuteQuery<Customer>(query, new { customerId }).FirstOrDefault();
        }

        public int InsertCustomer(Customer customer)
        {
            string query = @"INSERT INTO customers (first_name, last_name, email, phone_number, billing_address, shipping_address, created_at, is_active)
                         VALUES (@first_name, @last_name, @email, @phone_number, @billing_address, @shipping_address, @created_at, @is_active)
                         RETURNING customer_id;";
            return _dbExecutor.ExecuteScalar<int>(query, customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            string query = @"UPDATE customers SET first_name = @first_name, last_name = @last_name, 
                         email = @email, phone_number = @phone_number, billing_address = @billing_address, 
                         shipping_address = @shipping_address WHERE customer_id = @customer_id";
            _dbExecutor.ExecuteNonQuery(query, customer);
        }

        public void DeleteCustomer(int customerId)
        {
            string query = "DELETE FROM customers WHERE customer_id = @customerId";
            _dbExecutor.ExecuteNonQuery(query, new { customerId });
        }
    }
}
