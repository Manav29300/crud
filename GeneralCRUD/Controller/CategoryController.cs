using GeneralCRUD.Models;
using GeneralCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Category data is missing.");

            _categoryService.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategories), new { id = category.category_id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null) return NotFound();

            _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null) return NotFound();

            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
