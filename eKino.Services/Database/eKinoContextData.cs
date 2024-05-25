using eKino.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eKino.Services.Database
{
    partial class eKinoContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            #region Roles
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 1, Name = "Administrator" });
            modelBuilder.Entity<Role>().HasData(new Role { RoleId = 2, Name = "Client" });
            #endregion

            #region Users - Admin and client
            int userID = 0;

            //u:admin p:admin
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = ++userID,
                FirstName = "Administrator",
                LastName = "Administrator",
                Email = "admin@fit.ba",
                Username = "admin",
                PasswordHash = "JfJzsL3ngGWki+Dn67C+8WLy73I=",
                PasswordSalt = "7TUJfmgkkDvcY3PB/M4fhg==",
                Phone = "061456789",
                Status = true
            });

            //u:client p:client
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = ++userID,
                FirstName = "Client",
                LastName = "Client",
                Email = "client@fit.ba",
                Username = "client",
                PasswordHash = "Qt4/SE4hNB9rKyspn+e8q4C79Sw=",
                PasswordSalt = "l6n9Ck0LvsyNX1/V47AePQ==",
                Phone = "061123123",
                Status = true
            });


            modelBuilder.Entity<UserRole>().HasData(new UserRole() { UserRoleId = 1, UserId = 1, RoleId = 1, DateModified = DateTime.Today });
            modelBuilder.Entity<UserRole>().HasData(new UserRole() { UserRoleId = 2, UserId = 2, RoleId = 2, DateModified = DateTime.Today });
            #endregion

            #region Users - Client1 through Client10
            //u:client1 p:client
            for (int i = 1; i <= 10; i++)
            {
                int UID = ++userID;
                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = UID,
                    FirstName = "Client " + i,
                    LastName = "Client " + i,
                    Email = "client" + i + "@fit.ba",
                    Username = "client" + i,
                    PasswordHash = "Qt4/SE4hNB9rKyspn+e8q4C79Sw=",
                    PasswordSalt = "l6n9Ck0LvsyNX1/V47AePQ==",
                    Phone = "061123123",
                    Status = true
                });
                modelBuilder.Entity<UserRole>().HasData(new UserRole() { UserRoleId = UID, UserId = UID, RoleId = 2, DateModified = DateTime.Today });
            }
            #endregion

            #region Genre
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 1, Name = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 2, Name = "Drama" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 3, Name = "Horror" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 4, Name = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 5, Name = "Western" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 6, Name = "Thriller" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 7, Name = "Sci-fi" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 8, Name = "Romance" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 9, Name = "Crime" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 10, Name = "Adventure" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 11, Name = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 12, Name = "Mystery" });
            #endregion
            
            #region Director
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 1, FullName = "Taika Waititi", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 2, FullName = "Joseph Kosinski", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 3, FullName = "David Leitch", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 4, FullName = "Julius Avery", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 5, FullName = "Peter Jackson", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 6, FullName = "Colin Trevorrow", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 7, FullName = "Baltasar Kormákur", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 8, FullName = "James Cameron", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 9, FullName = "Sergio Leone", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 10,FullName = "Matt Reeves", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 11,FullName = "Robert Zemeckis", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 12,FullName = "Mark Steven Johnson", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 13,FullName = "Ti West", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 14,FullName = "Andrew Dominik", Biography = "", Photo = new byte[0] });
            modelBuilder.Entity<Director>().HasData(new Director() { DirectorId = 15,FullName = "Robert Eggers", Biography = "", Photo = new byte[0] });
            #endregion

            #region Movies and MovieGenres

            int MovieGenreID = 0;

            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 1,
                DirectorId = 1,
                Title = "Thor: Love and Thunder",
                Description = "Thor enlists the help of Valkyrie, Korg and ex-girlfriend Jane Foster to fight Gorr the God Butcher, who intends to make the gods extinct.",
                Year = 2022,
                RunningTime = 1 * 60 + 58,
                Photo = File.ReadAllBytes("Images/thor.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 1, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 1, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 1, GenreId = 4 });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 2,
                DirectorId = 2,
                Title = "Top Gun: Maverick",
                Description = "After thirty years, Maverick is still pushing the envelope as a top naval aviator, but must confront ghosts of his past when he leads TOP GUN's elite graduates on a mission that demands the ultimate sacrifice from those chosen to fly it.",
                Year = 2022,
                RunningTime = 2 * 60 + 10,
                Photo = File.ReadAllBytes("Images/topgunmaverick.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 2, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 2, GenreId = 2 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 3,
                DirectorId = 3,
                Title = "Bullet Train",
                Description = "Five assassins aboard a fast moving bullet train find out their missions have something in common.",
                Year = 2022,
                RunningTime = 2 * 60 + 7,
                Photo = File.ReadAllBytes("Images/bullettrain.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 3, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 3, GenreId = 4 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 3, GenreId = 6 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 4,
                DirectorId = 4,
                Title = "Samaritan",
                Description = "A young boy learns that a superhero who was thought to have gone missing after an epic battle twenty years ago may in fact still be around.",
                Year = 2022,
                RunningTime = 1 * 60 + 42,
                Photo = File.ReadAllBytes("Images/samaritan.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 4, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 4, GenreId = 2 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 4, GenreId = 11 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 5,
                DirectorId = 5,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                Year = 2001,
                RunningTime = 2 * 60 + 58,
                Photo = File.ReadAllBytes("Images/fellowship.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 5, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 5, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 5, GenreId = 11 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 6,
                DirectorId = 6,
                Title = "Jurassic World Dominion",
                Description = "Four years after the destruction of Isla Nublar, Biosyn operatives attempt to track down Maisie Lockwood, while Dr Ellie Sattler investigates a genetically engineered swarm of giant insects.",
                Year = 2022,
                RunningTime = 2 * 60 + 27,
                Photo = File.ReadAllBytes("Images/dominion.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 6, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 6, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 6, GenreId = 7 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 7,
                DirectorId = 7,
                Title = "Beast",
                Description = "A father and his two teenage daughters find themselves hunted by a massive rogue lion intent on proving that the Savanna has but one apex predator.",
                Year = 2022,
                RunningTime = 1 * 60 + 33,
                Photo = File.ReadAllBytes("Images/beast.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 7, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 7, GenreId = 2 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 7, GenreId = 3 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 8,
                DirectorId = 8,
                Title = "Avatar",
                Description = "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                Year = 2009,
                RunningTime = 2 * 60 + 42,
                Photo = File.ReadAllBytes("Images/avatar.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 8, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 8, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 8, GenreId = 11 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 9,
                DirectorId = 9,
                Title = "The Good, the Bad and the Ugly",
                Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                Year = 1966,
                RunningTime = 2 * 60 + 58,
                Photo = File.ReadAllBytes("Images/goodbadugly.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 9, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 9, GenreId = 5 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 10,
                DirectorId = 10,
                Title = "The Batman",
                Description = "When a sadistic serial killer begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
                Year = 2022,
                RunningTime = 2 * 60 + 56,
                Photo = File.ReadAllBytes("Images/batman.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 10, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 10, GenreId = 9 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 10, GenreId = 2 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 11,
                DirectorId = 11,
                Title = "Pinocchio",
                Description = "A puppet is brought to life by a fairy, who assigns him to lead a virtuous life in order to become a real boy.",
                Year = 2022,
                RunningTime = 1 * 60 + 45,
                Photo = File.ReadAllBytes("Images/pinocchio.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 11, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 11, GenreId = 4 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 11, GenreId = 2 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 12,
                DirectorId = 12,
                Title = "Love in the Villa",
                Description = "A young woman takes a trip to romantic Verona, Italy, after a breakup, only to find that the villa she reserved was double-booked, and she'll have to share her vacation with a cynical British man.",
                Year = 2022,
                RunningTime = 1 * 60 + 54,
                Photo = File.ReadAllBytes("Images/loveinthevilla.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 12, GenreId = 4 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 12, GenreId = 8 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 13,
                DirectorId = 13,
                Title = "X",
                Description = "In 1979, a group of young filmmakers set out to make an adult film in rural Texas, but when their reclusive, elderly hosts catch them in the act, the cast find themselves fighting for their lives.",
                Year = 2022,
                RunningTime = 1 * 60 + 45,
                Photo = File.ReadAllBytes("Images/x.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 13, GenreId = 3 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 13, GenreId = 12 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 13, GenreId = 6 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 14,
                DirectorId = 14,
                Title = "Blonde",
                Description = "A fictionalized chronicle of the inner life of Marilyn Monroe.",
                Year = 2022,
                RunningTime = 2 * 60 + 46,
                Photo = File.ReadAllBytes("Images/blonde.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 14, GenreId = 4 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 14, GenreId = 8 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 14, GenreId = 12 }
            );
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                MovieId = 15,
                DirectorId = 15,
                Title = "The Northman",
                Description = "From visionary director Robert Eggers comes The Northman, an action-filled epic that follows a young Viking prince on his quest to avenge his father's murder.",
                Year = 2022,
                RunningTime = 2 * 60 + 17,
                Photo = File.ReadAllBytes("Images/northman.jpg"),
            });
            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 15, GenreId = 1 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 15, GenreId = 10 },
                    new MovieGenre { MovieGenreId = ++MovieGenreID, MovieId = 15, GenreId = 2 }
            );
            #endregion

            #region Auditoriums
            for (int i = 1; i <= 3; i++)
            {
                modelBuilder.Entity<Auditorium>().HasData(new Auditorium()
                {
                    AuditoriumId = i,
                    Name = "Auditorium " + i
                });
            }
            modelBuilder.Entity<Auditorium>().HasData(new Auditorium()
            {
                AuditoriumId = 4,
                Name = "Auditorium 4 - 3D"
            });
            modelBuilder.Entity<Auditorium>().HasData(new Auditorium()
            {
                AuditoriumId = 5,
                Name = "Auditorium 5 - IMAX"
            });
            #endregion

            #region Projections

            int ProjectionID = 0;

            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 13, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 5.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 13, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 5.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 13, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 5.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 13, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 5.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 13, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 5.00m
            });

            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 14, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 7.50m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 14, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 7.50m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 14, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 7.50m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 14, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 7.50m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 14, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 7.50m
            });

            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 15, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 10.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 15, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 10.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 15, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 10.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 15, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 10.00m
            });
            modelBuilder.Entity<Projection>().HasData(new Projection()
            {
                ProjectionId = ++ProjectionID,
                DateOfProjection = new DateTime(2022, 9, 15, 20, 0, 0),
                AuditoriumId = (ProjectionID % 5) + 1,
                MovieId = ProjectionID,
                TicketPrice = 10.00m
            });

            int ReservationID = 0;
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 1,
                UserId = 3,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 9, 11, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 2,
                UserId = 3,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 9, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 3,
                UserId = 3,
                Row = 1,
                Column = 1,
                NumTickets = 1,
                DateOfReservation = new DateTime(2022, 9, 13, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 4,
                UserId = 3,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 9, 14, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 2,
                UserId = 4,
                Row = 1,
                Column = 1,
                NumTickets = 3,
                DateOfReservation = new DateTime(2022, 8, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 3,
                UserId = 5,
                Row = 1,
                Column = 1,
                NumTickets = 6,
                DateOfReservation = new DateTime(2022, 7, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 4,
                UserId = 6,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 6, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 4,
                UserId = 6,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 5, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 5,
                UserId = 7,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 4, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 6,
                UserId = 8,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 3, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 7,
                UserId = 9,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 2, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 8,
                UserId = 10,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2022, 1, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 9,
                UserId = 11,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2021, 12, 12, 15, 0, 0)
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation()
            {
                ReservationId = ++ReservationID,
                ProjectionId = 10,
                UserId = 12,
                Row = 1,
                Column = 1,
                NumTickets = 2,
                DateOfReservation = new DateTime(2021, 11, 12, 15, 0, 0)
            });

            #endregion
        }
    }
}
