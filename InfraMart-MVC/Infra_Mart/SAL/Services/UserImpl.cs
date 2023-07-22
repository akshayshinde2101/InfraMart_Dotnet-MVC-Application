using Infra_Mart.Models;
using Infra_Mart.DAL.Interfaces;
using Infra_Mart.DAL.Repository;
using System.Text;

namespace Infra_Mart.SAL.Services;

public class UserImpl : Interfaces.IUserInterface
{
    public  readonly IUserIointerface _userio;

    public UserImpl(IUserIointerface userio)
    {
        _userio = userio;
    }
    public  string ConvertToEncrypt(String password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        return Convert.ToBase64String(passwordBytes);
       
    }
    public  string convertToDecrypt(string base64EncodeData)
    {
        var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
        var result = Encoding.UTF8.GetString(base64EncodeBytes);
        return result;
    }
    public bool addNewUser(User user)
    {
        DateTime date = DateTime.Now.Date;
        User newuser =user;
        newuser.RegistrationDate = date;
        newuser.Password = ConvertToEncrypt(user.Password);
        Boolean status = _userio.addUser(newuser);
        return status;
    }

    public List<User> getAllUser()
    {
        List<User> alluser =  _userio.getuser();
        return alluser;
    }

    
}

