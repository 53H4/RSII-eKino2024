using AutoMapper;
using eKino.Model.Requests;
using eKino.Model.SearchObjects;
using eKino.Services.Database;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using eKino.Model;
using eKino.Services.Helpers;
using eKino.Services.Interfaces;

namespace eKino.Services.Implementations
{
    public class DirectorService : BaseCRUDService<Model.Director, Database.Director, DirectorSearchObject, DirectorUpsertRequest, DirectorUpsertRequest>, IDirectorService
    {
        public DirectorService(eKinoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Director> AddFilter(IQueryable<Database.Director> query, DirectorSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.FullName))
            {
                filteredQuery = filteredQuery.Where(x => x.FullName.Contains(search.FullName));
            }
            filteredQuery = filteredQuery.Where(x => !x.IsDeleted);

            return filteredQuery;
        }

    }
}