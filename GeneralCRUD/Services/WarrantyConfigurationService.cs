using GeneralCRUD.Models;

namespace GeneralCRUD.Services
{
    public class WarrantyConfigurationService
    {
        private readonly DbExecutor _dbExecutor;

        public WarrantyConfigurationService(DbExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        // Get all warranty configurations
        public List<WarrantyConfiguration> GetAllWarrantyConfigurations()
        {
            string query = "SELECT * FROM warranty_configuration";
            return _dbExecutor.ExecuteQuery<WarrantyConfiguration>(query);
        }

        // Get a specific warranty configuration by ID
        public WarrantyConfiguration GetWarrantyConfigurationById(int warrantyConfigId)
        {
            string query = "SELECT * FROM warranty_configuration WHERE warranty_config_id = @warrantyConfigId";
            return _dbExecutor.ExecuteQuery<WarrantyConfiguration>(query, new { warrantyConfigId }).FirstOrDefault();
        }

        // Insert a new warranty configuration
        public int InsertWarrantyConfiguration(WarrantyConfiguration warrantyConfig)
        {
            string query = @"INSERT INTO warranty_configuration 
                (product_id, warranty_duration, warranty_type, coverage, conditions, created_at)
                VALUES (@ProductId, @WarrantyDuration, @WarrantyType, @Coverage, @Conditions, @CreatedAt)
                RETURNING warranty_config_id;";
            return _dbExecutor.ExecuteScalar<int>(query, warrantyConfig);
        }

        // Update an existing warranty configuration
        public void UpdateWarrantyConfiguration(WarrantyConfiguration warrantyConfig)
        {
            string query = @"UPDATE warranty_configuration SET 
                product_id = @ProductId, 
                warranty_duration = @WarrantyDuration, 
                warranty_type = @WarrantyType, 
                coverage = @Coverage, 
                conditions = @Conditions
                WHERE warranty_config_id = @WarrantyConfigId";
            _dbExecutor.ExecuteNonQuery(query, warrantyConfig);
        }

        // Delete a warranty configuration
        public void DeleteWarrantyConfiguration(int warrantyConfigId)
        {
            string query = "DELETE FROM warranty_configuration WHERE warranty_config_id = @warrantyConfigId";
            _dbExecutor.ExecuteNonQuery(query, new { warrantyConfigId });
        }
    }
}
