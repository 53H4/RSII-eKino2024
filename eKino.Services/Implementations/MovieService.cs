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
    public class MovieService : BaseCRUDService<Model.Movie, Database.Movie, MovieSearchObject, MovieUpsertRequest, MovieUpsertRequest>, IMovieService
    {
        public MovieService(eKinoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Movie> AddFilter(IQueryable<Database.Movie> query, MovieSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Title))
            {
                filteredQuery = filteredQuery.Where(x => x.Title.Contains(search.Title));
            }

            if (search?.Year != null)
            {
                filteredQuery = filteredQuery.Where(x => x.Year == search.Year);
            }
            
            if (search?.DirectorId != null)
            {
                filteredQuery = filteredQuery.Where(x => x.DirectorId == search.DirectorId);
            }
            filteredQuery = filteredQuery.Where(x => !x.IsDeleted);

            return filteredQuery;
        }

        public override IQueryable<Database.Movie> AddInclude(IQueryable<Database.Movie> query, MovieSearchObject search = null)
        {
            query = query.Include(x => x.Director);
            query = query.Include("MovieGenres.Genre");
            return base.AddInclude(query, search);
        }

        public override Model.Movie Insert(MovieUpsertRequest insert)
        {
            var entity = base.Insert(insert);

            foreach (var genreId in insert.MovieGenreIdList)
            {
                Database.MovieGenre movieGenre = new Database.MovieGenre
                {
                    GenreId = genreId,
                    MovieId = entity.MovieId,
                };

                Context.MovieGenres.Add(movieGenre);
            }

            Context.SaveChanges();

            return entity;
        }

        public override Model.Movie? Update(int id, MovieUpsertRequest update)
        {
            var entity = Context.Movies.Where(x => x.MovieId == id).Include(x => x.MovieGenres).FirstOrDefault();

            if (entity != null)
            {
                Mapper.Map(update, entity);

                if (update.MovieGenreIdList != null)
                {
                    for (int i = 0; i < entity.MovieGenres.Count; i++)
                    {
                        if (!update.MovieGenreIdList.Any(roleId => roleId == entity.MovieGenres.ElementAt(i).GenreId))
                        {
                            entity.MovieGenres.Remove(entity.MovieGenres.ElementAt(i));
                            i--;
                        }
                    }

                    foreach (var genreId in update.MovieGenreIdList)
                    {
                        if (!entity.MovieGenres.Any(x => x.GenreId == genreId))
                        {
                            entity.MovieGenres.Add(new Database.MovieGenre
                            {
                                GenreId = genreId
                            });
                        }
                    }
                }
            }
            else
            {
                return null;
            }

            Context.SaveChanges();

            return Mapper.Map<Model.Movie>(entity);
        }
    }
}