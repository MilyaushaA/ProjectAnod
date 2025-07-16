using EloksalPro.Models;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        bool AuthenticateUser(NetworkCredential credential);
        List<string> GetByUsername();
        UserModel GetByUsername(string username);
        void UpdateUserName(int id, string username, string departament, int role, string login, string pass, string phoneNumber, string mail, string annotation);
    }
}
