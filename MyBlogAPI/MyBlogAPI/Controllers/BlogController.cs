using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.Models;
using MyBlogAPI.Provider;

namespace MyBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogProvider _provider;

        public BlogController(IBlogProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_provider.GetBlogs());
        }
    }
}