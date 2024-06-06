using eKino.Model;
using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using eKino.Services.Implementations;
using eKino.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKino.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]

    public class UserController :  BaseCRUDController<Model.User, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
            :base(service)
        {
            this.userService = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public override User Insert([FromBody] UserInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override User Update(int id, [FromBody] UserUpdateRequest update)
        {
            return base.Update(id, update);
        }

        [HttpGet("GetUser/{username}")]
        [AllowAnonymous]
        public async Task<User> GetUserByUsername(string username)
        {
            return await userService.GetUserByUsername(username);
        }

    }
}
