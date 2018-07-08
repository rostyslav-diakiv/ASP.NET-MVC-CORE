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

        public IActionResult Query1(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                var tuples = _queryService.GetUserPostsCommentsNumber(id).ToList();
                return View(tuples);
            }

            return NotFound();
        }

        public IActionResult Query2(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                // User' Post's all Comments
                var comments = _queryService.GetUserPostsComments(id); // 24
                return View(comments.ToList());
            }

            return NotFound();
        }

        public IActionResult Query3(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                ViewData["UserId"] = id;

                var todos = _queryService.GetUserCompletedTodos(id);
                return View(todos.ToList());

            }

            return NotFound();
        }

        public IActionResult Query4()
        {
            return View(_queryService.Query4().ToList());
        }

        public IActionResult Query5(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                var model = _queryService.Query5(id);
                return View(model); // TODO: Add validation for null
            }

            return NotFound();
        }

        public IActionResult Query6(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                var model = _queryService.Query6(id);
                return View(model); // TODO: Add validation for null
            }

            return NotFound();
        }
    }
}