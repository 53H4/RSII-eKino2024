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
    public class UserService : BaseCRUDService<Model.User, Database.User, UserSearchObject, UserInsertRequest, UserUpdateRequest>, IUserService
    {


        public UserService(eKinoContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.User Insert(UserInsertRequest insert)
        {

            if (insert.Password != insert.PasswordConfirm)
            {
                throw new UserException("Password and confirmation must be the same");
            }

            if (Context.Users.Any(x => x.Username == insert.Username))
            {
                throw new UserException("Username is already in use");
            }
            if (Context.Users.Any(x => x.Email == insert.Email))
            {
                throw new UserException("Email is already in use");
            }

            var entity = base.Insert(insert);


            foreach (var roleId in insert.RoleIdList)
            {
                Database.UserRole userRole = new Database.UserRole
                {
                    RoleId = roleId,
                    UserId = entity.UserId,
                    DateModified = DateTime.Now
                };

                Context.UserRoles.Add(userRole);
            }

            Context.SaveChanges();

            return entity;
        }

        public override Model.User? Update(int id, UserUpdateRequest update)
        {
            if (!string.IsNullOrEmpty(update.Password) && update.Password != update.PasswordConfirm)
            {
                throw new UserException("Password and confirmation must be the same");
            }

            if (Context.Users.Any(x => x.Username == update.Username && x.UserId != id))
            {
                throw new UserException("Username is already in use");
            }
            if (Context.Users.Any(x => x.Email == update.Email && x.UserId != id))
            {
                throw new UserException("Email is already in use");
            }

            var entity = Context.Users.Where(x => x.UserId == id).Include(x => x.UserRoles).FirstOrDefault();

            if (entity != null)
            {
                Mapper.Map(update, entity);
                if (!string.IsNullOrEmpty(update.Password))
                {
                    var salt = Hashing.GenerateSalt();
                    entity.PasswordSalt = salt;
                    entity.PasswordHash = Hashing.GenerateHash(salt, update.Password) ?? "";
                }

                if (update.RoleIdList != null)
                {
                    for (int i = 0; i < entity.UserRoles.Count; i++)
                    {
                        if (!update.RoleIdList.Any(roleId => roleId == entity.UserRoles.ElementAt(i).RoleId))
                        {
                            entity.UserRoles.Remove(entity.UserRoles.ElementAt(i));
                            i--;
                        }
                    }

                    foreach (var roleId in update.RoleIdList)
                    {
                        if (!entity.UserRoles.Any(x => x.RoleId == roleId))
                        {
                            entity.UserRoles.Add(new Database.UserRole
                            {
                                RoleId = roleId,
                                DateModified = DateTime.Now,
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

            return Mapper.Map<Model.User>(entity);
        }

        public override void BeforeInsert(UserInsertRequest insert, Database.User entity)
        {
            var salt = Hashing.GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = Hashing.GenerateHash(salt, insert.Password) ?? "";
            base.BeforeInsert(insert, entity);
        }


        public override IQueryable<Database.User> AddFilter(IQueryable<Database.User> query, UserSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                filteredQuery = filteredQuery.Where(x => x.Username.Contains(search.Username));
            }

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filteredQuery = filteredQuery.Where(x => (x.FirstName + " " + x.LastName).Contains(search.Name));
            }
            filteredQuery = filteredQuery.Where(x => !x.IsDeleted);

            return filteredQuery;
        }

        public override IQueryable<Database.User> AddInclude(IQueryable<Database.User> query, UserSearchObject search = null)
        {
            if (search?.IncludeRoles == true)
            {
                query = query.Include("UserRoles.Role");
            }
            return query;
        }

        public Model.User? Login(string username, string password)
        {
            var entity = Context.Users.Include("UserRoles.Role").FirstOrDefault(x => x.Username == username);
            if (entity == null)
            {
                return null;
            }

            var hash = Hashing.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return Mapper.Map<Model.User>(entity);
        }
        public async Task<Model.User?> GetUserByUsername(string username)
        {
            var userEntity = await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return userEntity != null ? Mapper.Map<Model.User>(userEntity) : null;
        }

    }
}
