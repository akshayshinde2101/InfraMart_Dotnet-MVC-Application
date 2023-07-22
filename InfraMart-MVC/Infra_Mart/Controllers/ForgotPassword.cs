using Microsoft.AspNetCore.Mvc;
using Infra_Mart.Models;
using System.Net.Mail;
using Infra_Mart.DataContext;
using Microsoft.AspNetCore.Identity;
using NuGet.Configuration;
using System.Net;
using Infra_Mart.SAL.Interfaces;

namespace Infra_Mart.Controllers
{
    public class ForgotPassword : Controller
    {
        private readonly CollectionContex _ctx;
        private readonly IUserInterface _userInterface;
        public ForgotPassword(CollectionContex ctx, IUserInterface userInterface)
        {
            _ctx = ctx;
            _userInterface = userInterface;
        }
        public IActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPass(string email)
        {
            Console.WriteLine("inside forgot password");
            Console.WriteLine(email);

            Random rnd = new Random();
            int otp = rnd.Next(000000, 999999);
            User user = FindByEmail(email);
            Console.WriteLine(user);
            HttpContext.Session.SetInt32("OTP", otp);
            HttpContext.Session.Set<User>("forgotpassuser", user);
            string tomail = user.Email;
            string fromMail = "inframartonline@gmail.com";
            string fromPassword = "afnzxmohndggfazb";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "OTP From InfraMart";
            message.To.Add(new MailAddress(tomail));
            message.Body = "Your OTP Is" + " " + otp;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,

            };
            smtpClient.Send(message);

            return RedirectToAction("VerifyOtp", "ForgotPassword");
        }


        public IActionResult VerifyOtp()
        {
            return View();
        }
        public IActionResult UpdatePassword(string otp)
        {
            int otp1 = Convert.ToInt32(otp);
            int otp2 = (int)HttpContext.Session.GetInt32("OTP");
            User user = HttpContext.Session.Get<User>("forgotpassuser");
            if (otp1 == otp2)
            {
                ViewData["user"] = user;
            }
            return View();
        }

        [HttpPost]
        public string ChangePassword([FromBody] User user)
        {
            Console.WriteLine(user);
            User olduser = HttpContext.Session.Get<User>("forgotpassuser");
            olduser.Password = _userInterface.ConvertToEncrypt(user.Password);
            _ctx.User.Update(olduser);
            _ctx.SaveChanges();
            return "Password updated Succefully";
        }
        public User FindByEmail(string email)
        {
            List<User> userlist = _ctx.User.ToList();
            foreach (User user in userlist)
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }

            }
            return null;
        }
    }
}
