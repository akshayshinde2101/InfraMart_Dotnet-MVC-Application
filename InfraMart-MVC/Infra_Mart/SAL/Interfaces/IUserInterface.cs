using Infra_Mart.Models;

namespace Infra_Mart.SAL.Interfaces
{
    public interface IUserInterface
    {
        bool addNewUser(User u);
        List<User> getAllUser();

        string ConvertToEncrypt(string password);
        string convertToDecrypt(string base64EncodeData);
    }
}
