using AutoMapper;
using eKino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKino.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Auditorium, Model.Auditorium>();
            CreateMap<Database.Director, Model.Director>();
            CreateMap<Database.Genre, Model.Genre>();
            CreateMap<Database.Movie, Model.Movie>();
            CreateMap<Database.MovieGenre, Model.MovieGenre>();
            CreateMap<Database.Projection, Model.Projection>();
            CreateMap<Database.Reservation, Model.Reservation>();
            CreateMap<Database.Rating, Model.Rating>();
            CreateMap<Database.Transaction, Model.Transaction>();
            CreateMap<Database.User, Model.User>();
            CreateMap<Database.UserRole, Model.UserRole>();
            CreateMap<Database.Role, Model.Role>();

            CreateMap<AuditoriumUpsertRequest, Database.Auditorium>();
            CreateMap<DirectorUpsertRequest, Database.Director>();
            CreateMap<GenreUpsertRequest, Database.Genre>();
            CreateMap<MovieUpsertRequest, Database.Movie>();
            CreateMap<ProjectionUpsertRequest, Database.Projection>();
            CreateMap<ReservationUpsertRequest, Database.Reservation>();
            CreateMap<RatingUpsertRequest, Database.Rating>();
            CreateMap<TransactionUpsertRequest, Database.Transaction>();
            CreateMap<UserInsertRequest, Database.User>();
            CreateMap<UserUpdateRequest, Database.User>();

        }
    }
}
