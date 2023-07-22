using Infra_Mart.Models;
using Infra_Mart.DAL.Interfaces;
using Infra_Mart.DataContext;

namespace Infra_Mart.DAL.Repository
{
    public class UserIoManager : IUserIointerface
    {

        public readonly CollectionContex _ctx;
        public UserIoManager(CollectionContex ctx)
        {
            _ctx = ctx;
        }
        public bool addUser(User u)
        {
            _ctx.User.Add(u);
        
            _ctx.SaveChanges();
            return true;
        }

        public List<User> getuser()
        {
           // CollectionContex ctx = new CollectionContex();
            var Users = from user in _ctx.User select user;
            return Users.ToList<User>();
        }
    }
}
