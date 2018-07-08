using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using System.Linq;

    using WebApp.Interfaces;

    public class TodosController : Controller
    {
        private readonly IQueryService _queryService;

        public TodosController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        // GET: Todos/Index?userid=5
        public IActionResult Index(string userid) // userid
        {
            if (int.TryParse(userid, out var id))
            {
                var todos = _queryService.GetUserTodos(id);
                if (todos != null && todos.Any())
                {
                    ViewData["UserName"] = todos[0].User.Name;
                    return View(todos);
                }
            }

            return View(null);
        }

        // GET: Todos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _queryService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }
    }
}