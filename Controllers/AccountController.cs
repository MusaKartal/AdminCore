using AdminCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdminCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.admins.FirstOrDefault(e => e.Email.Equals(email)
            && e.Password.Equals(password));
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("Name",user.Name);
                return Redirect("/Admin/Index");
            }

            return View();
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
    }
}
