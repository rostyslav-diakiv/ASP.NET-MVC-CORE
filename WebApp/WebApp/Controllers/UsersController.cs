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

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _queryService.GetUserById(id);
            return View(user);
        }
    }
}