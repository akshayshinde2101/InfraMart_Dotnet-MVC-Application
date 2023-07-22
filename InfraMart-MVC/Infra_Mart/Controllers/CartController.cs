using Infra_Mart.DataContext;
using Infra_Mart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Org.BouncyCastle.Utilities.Collections;

namespace Infra_Mart.Controllers
{
    public class CartController : Controller
    {
        private readonly CollectionContex _ctx;
        public CartController(CollectionContex ctx)
        {
            _ctx = ctx;
        }
       
        public string AddToCart([FromBody] int[] arr)
        {
            List<Product> products = _ctx.Product.ToList();
            List<Product> cartproduct = new List<Product>();

            HttpContext.Session.SetString("cartlist", "cartproduct");

            //HttpContext.Session.Set<List<cementdata1>>("info", cartlist);

            User user = HttpContext.Session.Get<User>("LoginUser");
            Console.WriteLine("Cartcontroller"+user);
            Cart addCart = new Cart();
            addCart.UserCartId =user.UserId;
            foreach (Product product in products)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (product.ProductId == arr[i])
                    {
                        cartproduct.Add(product);
                        addCart.ProductCartId = product.ProductId;
                        _ctx.Cart.Add(addCart);

                    }

                }
                      
            }
            _ctx.SaveChanges();
            foreach (Product p in cartproduct)
            {
                Console.WriteLine(p);
            }
            HttpContext.Session.Set<List<Product>>("cartproducts", cartproduct);

            return "cartProductGet";
        }

        public IActionResult ShowCart()
        {
            Console.WriteLine("ShowCart Called");
           string sess= HttpContext.Session.GetString("cartlist");
           List<Product> cartlist= HttpContext.Session.Get<List<Product>>("cartproducts");
           
            Console.WriteLine(sess);
            foreach(Product p in cartlist)
            {
                Console.WriteLine(p);
            }
            ViewData["CartProducts"] = cartlist;
            return View();
        }
    }
}
