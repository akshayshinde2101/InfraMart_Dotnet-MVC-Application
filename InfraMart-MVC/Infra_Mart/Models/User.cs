using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infra_Mart.Models
{
    
    public class User
    {
        [Key]
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get;set; }

        
        public string Email { get; set; }

        
        public string Password { get; set; }
        public string Role { get; set; }
        public int Active { get; set; }
        public DateTime RegistrationDate { get; set; }
        public User()
        { }

        // public User()
        // {
        //     this.Role = "user";
        //     this.Active = 1;
        //     this.RegistrationDate = DateTime.Now.Date;

        // }
        public User(string firstname, string lastname, string email, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
        }
        public User(string firstname,string lastname,string email,string password,string role,int active,DateTime date)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.Active = active;
            this.RegistrationDate = date;

            
        }
        public override string ToString()
        {
            return ( "UserId :"+UserId+"Name:" + FirstName + "LastName" + LastName + "Email" + Email);
        }
    }
}
