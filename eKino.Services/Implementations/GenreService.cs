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
    public class GenreService : BaseCRUDService<Model.Genre, Database.Genre, GenreSearchObject, GenreUpsertRequest, GenreUpsertRequest>, IGenreService
    {
        public GenreService(eKinoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Genre> AddFilter(IQueryable<Database.Genre> query, GenreSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.Contains(search.Name));
            }
            filteredQuery = filteredQuery.Where(x => !x.IsDeleted);

            return filteredQuery;
        }

    }
}