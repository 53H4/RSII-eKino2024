using AutoMapper;
using eKino.Model;
using eKino.Model.SearchObjects;
using eKino.Services.Database;
using eKino.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKino.Services.Implementations
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate>
        : BaseService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate>
            where T : Model.SoftDeletableEntity where TDb : Database.SoftDeletableEntity where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(eKinoContext context, IMapper mapper)
        : base(context, mapper) { }

        public virtual T Insert(TInsert insert)
        {
            var set = Context.Set<TDb>();

            TDb entity = Mapper.Map<TDb>(insert);

            set.Add(entity);

            BeforeInsert(insert, entity);

            Context.SaveChanges();

            return Mapper.Map<T>(entity);
        }

        public virtual void BeforeInsert(TInsert insert, TDb entity)
        {

        }

        public virtual T? Update(int id, TUpdate update)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
            {
                Mapper.Map(update, entity);
            }
            else
            {
                return null;
            }

            Context.SaveChanges();

            return Mapper.Map<T>(entity);

        }

        public virtual T? Delete(int id)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            else
            {
                return null;
            }

            Context.SaveChanges();

            return Mapper.Map<T>(entity);
        }
    }
}
