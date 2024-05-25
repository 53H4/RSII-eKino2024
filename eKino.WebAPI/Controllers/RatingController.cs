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
    public class RatingController : BaseCRUDController<Model.Rating, RatingSearchObject, RatingUpsertRequest, RatingUpsertRequest>
    {
        public RatingController(IRatingService service)
            : base(service)
        {
        }
    }
}
