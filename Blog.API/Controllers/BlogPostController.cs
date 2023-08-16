using AutoMapper;
using Blog.API.DTOs;
using Blog.Core.Entities;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BlogPostController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromServices] IGetBlogPostService getBlogPostService, int id)
        {
            var result = await getBlogPostService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BlogPostDto>(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromServices] IGetAllBlogPostService getAllBlogPostService)
        {
            var results = await getAllBlogPostService.GetAll();

            return Ok(_mapper.Map<IEnumerable<BlogPostDto>>(results));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromServices] IAddBlogPostService addBlogPostService, CreateBlogPostDto blogPostDto)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDto);

            var result = await addBlogPostService.Add(blogPost);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<BlogPostDto>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromServices] IUpdateBlogPostService updateBlogPostService, int id, UpdateBlogPostDto blogPostDto)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDto);

            var result = await updateBlogPostService.Update(id, blogPost);
            if (result == null)
            {
                return NotFound(blogPost);
            }

            return Ok(_mapper.Map<BlogPostDto>(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromServices] IRemoveBlogPostService removeBlogPostService, int id)
        {
            var result = await removeBlogPostService.Remove(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPatch("activate/{id}")]
        public async Task<IActionResult> Activate([FromServices] IActivateBlogPostService activateBlogPostService, int id)
        {
            var result = await activateBlogPostService.Activate(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BlogPostDto>(result));
        }
    }
}