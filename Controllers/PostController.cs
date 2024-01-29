using BlogerAPI.DAL;
using BlogerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly MyAppDBContext _context;

        public PostController(MyAppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var post = _context.Posts.ToList();
                if (post.Count == 0)
                {
                    return NotFound("Post not available.");
                }
                return Ok(post);
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
                var post = _context.Posts.Find(id);
                if (post == null)
                {
                    return NotFound($"Post details not found with id {id}");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PostModel model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Posted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(PostModel model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is Invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Post Id {model.Id} is invalid.");
                }
            }
            try
            {
                var post = _context.Posts.Find(model.Id);
                if (post == null)
                {
                    return NotFound($"Post not found with id {model.Id}");
                }
                post.ImageUrl = model.ImageUrl;
                post.CategoryName = model.CategoryName;
                post.Title = model.Title;
                post.Summary = model.Summary;
                post.Content = model.Content;
                post.Status = model.Status;
                post.Created = model.Created;
                _context.SaveChanges();
                return Ok("Post details updated.");
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
                var post = _context.Posts.Find(id);
                if (post == null)
                {
                    return NotFound($"Post not found whit is {id}");

                }
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return Ok("Post details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
