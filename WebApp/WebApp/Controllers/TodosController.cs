using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using WebApp.Interfaces;

    public class TodosController : Controller
    {
        private readonly IQueryService _queryService;

        public TodosController(IQueryService queryService)
        {
            _queryService = queryService;
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