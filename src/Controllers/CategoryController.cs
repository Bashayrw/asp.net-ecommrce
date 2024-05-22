using System.Security.Claims;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Controllers;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace CodeCrafters_backend_teamwork.src.Controller

{
    public class CategoryController : CustomizedController

    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)

        {

            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> FindMany()
        {
            
            return Ok(_categoryService.FindMany());

        }

        [HttpGet("{categoryId}")]
        public Category? FindOne(Guid categoryId)
        {

            return _categoryService.FindOne(categoryId);

        }


        [HttpPost]
        public ActionResult<IEnumerable<CategoryReadDto>> CreateOne([FromBody] CategoryCreateDto newCategory)

        {

            return CreatedAtAction(nameof(CreateOne), _categoryService.CreateOne(newCategory));

        }



        [HttpDelete("{categoryId}")]
        public IEnumerable<Category>? DeleteCategory([FromRoute] Guid categoryId)
        {
            return _categoryService.DeleteCategory(categoryId);
        }

        [HttpPatch("{categoryId}")]
        public Category UpdateOne(Guid categoryId, Category updatedCategory)
        {
            return _categoryService.UpdateOne(categoryId, updatedCategory);
        }

    }
}
