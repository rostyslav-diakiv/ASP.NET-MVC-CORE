using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using WebApp.Interfaces;

    public class PostsController : Controller
    {

        private readonly IQueryService _queryService;

        public PostsController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        // GET: Posts
        [HttpGet]
        public IActionResult Index(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));

            }

            return NotFound();
        }

        // GET: Posts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _queryService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
