using GeneralCRUD.Models;
using GeneralCRUD;
namespace GeneralCRUD.Services
{
    public class CategoryService
    {
        private readonly DbExecutor _dbExecutor;

        public CategoryService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM categories";
            return _dbExecutor.ExecuteQuery<Category>(query);
        }

        public Category GetCategoryById(int categoryId)
        {
            string query = "SELECT * FROM categories WHERE category_id = @categoryId";
            return _dbExecutor.ExecuteQuery<Category>(query, new { categoryId }).FirstOrDefault();
        }

        public int InsertCategory(Category category)
        {
            string query = @"INSERT INTO categories (category_name, category_code, description, parent_category_id, category_path, created_at, is_deleted)
                         VALUES (@category_name, @category_code, @description, @parent_category_id, @category_path, @created_at, @is_deleted)
                         RETURNING category_id;";
            return _dbExecutor.ExecuteScalar<int>(query, category);
        }

        public void UpdateCategory(Category category)
        {
            string query = @"UPDATE categories SET category_name = @category_name, category_code = @category_code, 
                         description = @description WHERE category_id = @category_id";
            _dbExecutor.ExecuteNonQuery(query, category);
        }

        public void DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM categories WHERE category_id = @categoryId";
            _dbExecutor.ExecuteNonQuery(query, new { categoryId });
        }
    }
}
