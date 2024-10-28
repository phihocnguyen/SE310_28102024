using Microsoft.AspNetCore.Mvc;
using SE310_28102024.Models;

namespace SE310_28102024.Controllers
{
    public class AccessController : Controller
    {
        ProductContext db = new ProductContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.UserName.ToString());
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Access");
        
        }
    }
}
