using eKino.Model;
using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKino.Services.Interfaces
{
    public interface IUserService : ICRUDService<User, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        User? Login(string username, string password);

        Task<User?> GetUserByUsername(string username);
    }
}
