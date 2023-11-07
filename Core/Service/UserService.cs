using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepositorii;
        public UserService(IUserRepository userRepositorii)
        {
            _userRepositorii = userRepositorii;
        }
        public IUser GetUserById(Guid id)
        {
            return _userRepositorii.GetUserById(id);
        }

        public bool IsUsedEmail(string? Email)
        {
            if (_userRepositorii.GetUserByEmail(Email) != null)
                return true;
            return false;
        }


        public bool CreateUser(IUser user)
        {
            user.Id = Guid.NewGuid();
            user.CreateData = DateTime.Now;
            return _userRepositorii.CreateUser(user);
        }
        public bool UpdateUser(IUser user)
        {
            var userFromDb = _userRepositorii.GetUserById(user.Id);
            if (userFromDb == null)
            {
                return false;
            }
            userFromDb.Name = user.Name;
            userFromDb.Age = user.Age;
            userFromDb.Password = user.Password;

            if (user.Address != null)
            {
                if (userFromDb.Address != null)
                {
                    userFromDb.Address.Street = user.Address.Street;
                    userFromDb.Address.City = user.Address.City;
                    userFromDb.Address.PostalCode = user.Address.PostalCode;
                }
                else
                {
                    userFromDb.Address = new Address
                    {
                        Street = user.Address.Street,
                        City = user.Address.City,
                        PostalCode = user.Address.PostalCode
                    };
                }
            }

            return _userRepositorii.UpdateUser(user);
        }

        public IEnumerable<IUser> GetAllUser()
        {
           return  _userRepositorii.GetAllUser();
        }

        public IUser? GetUserByEmail(string email)
        {
            return _userRepositorii.GetUserByEmail(email);
        }
    }
}
