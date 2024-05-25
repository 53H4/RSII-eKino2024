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
    public interface IAuditoriumService : ICRUDService<Auditorium, AuditoriumSearchObject, AuditoriumUpsertRequest, AuditoriumUpsertRequest>
    {
    }
}
