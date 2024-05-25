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
    [Authorize]
    public class ProjectionController : BaseCRUDController<Model.Projection, ProjectionSearchObject, ProjectionUpsertRequest, ProjectionUpsertRequest>
    {
        public ProjectionController(IProjectionService service)
            : base(service)
        {
        }
    }
}
