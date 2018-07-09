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
                ViewData["UserId"] = id;

                var tuples = _queryService.GetUserPostsCommentsNumber(id);
                if (tuples != null)
                {
                    return View(tuples.ToList());
                }
            }

            return View(null);
        }

        public IActionResult Query2(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                ViewData["UserId"] = id;

                var comments = _queryService.GetUserPostsComments(id);
                if (comments != null)
                {
                    return View(comments.ToList());
                }
            }

            return View(null);
        }

        public IActionResult Query3(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                ViewData["UserId"] = id;

                var todos = _queryService.GetUserCompletedTodos(id);
                if (todos != null)
                {
                    return View(todos.ToList());
                }

            }

            return View(null);
        }

        public IActionResult Query4()
        {
            return View(_queryService.Query4().ToList());
        }

        public IActionResult Query5(string stringId)
        {
            if (int.TryParse(stringId, out var id))
            {
                ViewData["UserId"] = id;

                var model = _queryService.Query5(id);
                if (model.User != null)
                {
                    return View(model);
                }
            }

            return View(null);
        }

        public IActionResult Query6(string stringId)
        { 
            if (int.TryParse(stringId, out var id))
            {
                ViewData["PostId"] = id;

                var model = _queryService.Query6(id);
                if (model.Post != null)
                {
                    return View(model);
                }
            }

            return View(null);
        }
    }
}