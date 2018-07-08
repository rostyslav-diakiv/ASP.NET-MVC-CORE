using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using WebApp.Interfaces;

    public class UsersController : Controller
    {
        private readonly IQueryService _queryService;

        public UsersController(IQueryService queryService)
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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _queryService.GetUserById(id);
            return View(user);
        }
    }
}