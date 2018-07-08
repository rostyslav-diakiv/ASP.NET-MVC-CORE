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

        // GET: Posts/Details/5
        public IActionResult Index(int? id) // userid
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
