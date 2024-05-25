using eKino.Model;
using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using eKino.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKino.WebAPI.Controllers
{

    public class RoleController : BaseController<Model.Role, BaseSearchObject>
    {
        public RoleController(IService<Model.Role, BaseSearchObject> service)
            : base(service)
        {
        }
    }
}
