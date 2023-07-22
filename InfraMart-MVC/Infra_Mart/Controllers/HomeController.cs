
using Infra_Mart.DataContext;
using Infra_Mart.Models;
using Infra_Mart.SAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Infra_Mart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInterface _IUser;
        private readonly CollectionContex _ctx;
        public HomeController(IUserInterface IUser,CollectionContex ctx)
        {
            _IUser = IUser;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            
            Console.WriteLine("method Called");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {

            Console.WriteLine(email);
            Console.WriteLine(password);
            List<User> ulist = _IUser.getAllUser();
            string pass = _IUser.ConvertToEncrypt(password);
            foreach(User u in ulist)
            {
               
                if (u.Email.Equals(email) && u.Password.Equals(pass))
                {
                    HttpContext.Session.Set<User>("LoginUser", u);
                    if (u.Role.Equals("admin"))
                        {
                        return RedirectToAction("Admin", "Admin");
                        }
                    else if(u.Role.Equals("manager"))
                    {
                        return RedirectToAction("Manager", "Admin");
                    }
                    return RedirectToAction("ViewAll", "Product");

                }
                   
               
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
       
            Boolean status = _IUser.addNewUser(user);
            Console.WriteLine(status);
            if (status)
            {
            return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Home", "about");
            }
            
        }

        [HttpGet]
        public IActionResult ShowAllUser()
        {
            List<User> users = _IUser.getAllUser();
            return View(users);


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}