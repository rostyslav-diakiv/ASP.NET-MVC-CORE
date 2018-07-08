using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using System.Linq;

    using WebApp.Interfaces;

    public class QueriesController : Controller
    {
        private readonly IQueryService _queryService;

        public QueriesController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public IActionResult Query1(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));
            }

            return NotFound();
        }

        public IActionResult Query2(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                // User' Post's all Comments
                var comments = _queryService.GetUserPostsComments(id); // 24
                return View(comments.comments.ToList());
            }

            return NotFound();
        }

        public IActionResult Query3(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));

            }

            return NotFound();
        }

        public IActionResult Query4(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));

            }

            return NotFound();
        }

        public IActionResult Query5(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));

            }

            return NotFound();
        }

        public IActionResult Query6(string userId)
        {
            if (int.TryParse(userId, out var id))
            {
                return View(_queryService.GetUserPostsCommentsNumber(id));

            }

            return NotFound();
        }
    }
}