using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IUserRepository
    {
        IUser GetUserById(Guid id);
        bool CreateUser(IUser user);
        IUser GetUserByEmail(string email);
        IEnumerable<IUser> GetAllUser();
        bool UpdateUser(IUser user);
    }
}
