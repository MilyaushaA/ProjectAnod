using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EloksalPro.Models;
using EloksalPro.EfStructures;
using EloksalPro.Repositories.Base;

namespace EloksalPro.Repositories
{
    public class UserRepository : BaseRepo<UserModel>, IUserRepository
    { 
        public bool AuthenticateUser(NetworkCredential credential)
        {
             var validUser = Table.Any(u => u.Login == credential.UserName && u.Password == credential.Password);
                return validUser;   
        }
        public List<string> GetByUsername()
        {
            List<string> list = new List<string>();
            var inventory = Table.Select(p => p.Name.Trim());
            list = new List<string>(inventory);
            return list;
        }
        public List<string> GetByUsernameRoleTwo()
        {
            List<string> list = new List<string>();
            var inventory = Table.Where(p=>p.Role==2 || p.Role == 1 && (p.Department=="Цех Упаковки" || p.Department == "Начальник СГП")).Select(p => p.Name.Trim());
            list = new List<string>(inventory);
            return list;
        }
        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            user = Table.FirstOrDefault(p => p.Login == username);
            return user;
        }
        public void UpdateUserName(int id, string username, string departament, int role, string login, string pass,string phoneNumber,string mail,string annotation)
        {
            var user = Table.FirstOrDefault(p => p.Id == id);
            user.Name = username;
            user.Department = departament;
            user.Role = role;
            user.Login = login;
            user.Password = pass;
            user.PhoneNumber = phoneNumber;
            user.Email = mail;
            user.Annotation= annotation;
            Context.SaveChanges();
            
        }    
    }
}
