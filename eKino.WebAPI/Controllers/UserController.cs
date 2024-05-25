using eKino.Model;
using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using eKino.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKino.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :  BaseCRUDController<Model.User, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        public UserController(IUserService service)
            :base(service)
        {
        }

        [Authorize(Roles = "Administrator")]
        public override User Insert([FromBody] UserInsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator")]
        public override User Update(int id, [FromBody] UserUpdateRequest update)
        {
            return base.Update(id, update);
        }

    }
}
