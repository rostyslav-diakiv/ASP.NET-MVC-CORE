using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using System.Linq;

    using WebApp.Interfaces;

    public class PostsController : Controller
    {
        private readonly IQueryService _queryService;

        public PostsController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        // GET: Posts/Intex?userid=5
        public IActionResult Index(string userid) // userid
        {
            if (int.TryParse(userid, out var id))
            {
                var posts = _queryService.GetUserPosts(id);
                if (posts != null && posts.Any())
                {
                    ViewData["UserName"] = posts[0].User.Name;
                    return View(posts);
                }
            }

            return View(null);
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
