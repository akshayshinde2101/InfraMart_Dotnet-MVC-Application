using Microsoft.AspNetCore.Mvc;
using Infra_Mart.Models;
using Infra_Mart.DataContext;
using Infra_Mart.SAL.Interfaces;
using Mysqlx.Crud;

namespace Infra_Mart.Controllers
{
    public class AdminController : Controller
    {

        private readonly CollectionContex _ctx;
        private readonly IUserInterface _userInterface;

        public AdminController(CollectionContex ctx, IUserInterface userInterface)
        {
            _ctx = ctx;
            _userInterface = userInterface;
        }
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult ViewAllAdmin()
        {
            var products = _ctx.Product.ToList();
            ViewData["products"] = products;
            return View();
        }


        [HttpPost]
        public string AddUser([FromBody] User user)
        {
            User newUser = new User();
            newUser = user;
            newUser.Password = _userInterface.ConvertToEncrypt(user.Password);
            newUser.RegistrationDate = DateTime.Now.Date;
            _ctx.User.Add(newUser);
            int s = _ctx.SaveChanges();
            Console.WriteLine("value of s is" + s);


            return "user Added";
        }

        public IActionResult ShowAllUser()
        {
            List<User> userlist = _ctx.User.ToList();
            ViewData["userlist"] = userlist;
            return View();
        }

        [HttpPost]
        public string DeleteUser([FromBody] User user)
        {
            Console.WriteLine(user.UserId);
            List<User> userlist = _ctx.User.ToList();
            foreach(User u in userlist)
            {
                if(u.UserId==user.UserId)
                {
                    Console.WriteLine(u);
                    _ctx.User.Remove(u);
                    _ctx.SaveChanges();

                    return "user-delete";
                }
            }
            return "Not-Found";

        }


       


        [HttpPost]
        public string RemovePrdouct([FromBody] Product prod)
        {
            Console.WriteLine("Method Called");
            Console.WriteLine(prod.ProductId);
            List<Product> prodcuts = _ctx.Product.ToList();

             foreach(Product p in prodcuts)
                 if(p.ProductId== prod.ProductId)
                 {
                     _ctx.Product.Remove(p);
                     _ctx.SaveChanges();
                 }
             return "Product-Delete";
            
        }
    }
}
