using BlogerAPI.DAL;
using BlogerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyAppDBContext _context;
        public CategoryController(MyAppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var category = _context.Categorys.ToList();
                if (category.Count == 0)
                {
                    return NotFound("Category not available.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var category = _context.Categorys.Find(id);
                if (category == null)
                {
                    return NotFound($"Category details not found with id {id}");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(CategoryModel model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Product Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(CategoryModel model)
        {
            if(model == null || model.Id ==0) 
            {
                if(model == null)
                {
                    return BadRequest("Model data is Invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Category Id {model.Id} is invalid.");
                }
            }
            try
            {
                var category = _context.Categorys.Find(model.Id);
                if (category == null)
                {
                    return NotFound($"Category not found with id {model.Id}");
                }
                category.CategoryName = model.CategoryName;
                category.Status = model.Status;
                category.Created = model.Created;
                _context.SaveChanges();
                return Ok("Category details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categorys.Find(id);
                if (category == null)
                {
                    return NotFound($"Category not found whit is {id}");

                }
                _context.Categorys.Remove(category);
                _context.SaveChanges();
                return Ok("Catategory details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}
