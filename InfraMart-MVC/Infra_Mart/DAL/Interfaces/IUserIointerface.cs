using Infra_Mart.Models;

namespace Infra_Mart.DAL.Interfaces
{
    public interface IUserIointerface
    {
        bool addUser(User u);
        List<User> getuser();
    }
}
