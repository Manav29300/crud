using GeneralCRUD.Models;
using GeneralCRUD;
namespace GeneralCRUD.Services
{
    public class ProductService
    {
        private readonly DbExecutor _dbExecutor;

        public ProductService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        // Fetch all products
        public List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM products";
            return _dbExecutor.ExecuteQuery<Product>(query);
        }

        // Fetch a product by its ID
        public Product GetProductById(int productId)
        {
            string query = "SELECT * FROM products WHERE product_id = @productId";
            return _dbExecutor.ExecuteQuery<Product>(query, new { productId }).FirstOrDefault();
        }

        // Insert a new product
        public int InsertProduct(Product product)
        {
            string query = @"INSERT INTO products (product_name, product_code, description, category, unit_of_measure, cost, price, created_at)
                         VALUES (@product_name, @product_code, @description, @category, @unit_of_measure, @cost, @price, @created_at)
                         RETURNING product_id;";
            return _dbExecutor.ExecuteScalar<int>(query, product);
        }

        // Update a product by ID
        public void UpdateProduct(int productId, Product product)
        {
            string query = @"UPDATE products 
                             SET product_name = @product_name, 
                                 product_code = @product_code, 
                                 description = @description, 
                                 category = @category, 
                                 unit_of_measure = @unit_of_measure, 
                                 cost = @cost, 
                                 price = @price 
                             WHERE product_id = @product_id";

            var parameters = new
            {
                product.product_name,
                product.product_code,
                product.description,
                product.category,
                product.unit_of_measure,
                product.cost,
                product.price,
                product_id = productId
            };

            _dbExecutor.ExecuteNonQuery(query, parameters);
        }

        // Delete a product by ID
        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM products WHERE product_id = @productId";
            _dbExecutor.ExecuteNonQuery(query, new { productId });
        }
    }
}
