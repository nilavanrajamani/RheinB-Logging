using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EarlyInitializationSample.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContextCatalog dbContextCatalog;
        private readonly ILogger logger;

        public Repository(DbContextCatalog dbContextCatalog, ILogger logger)
        {
            this.dbContextCatalog = dbContextCatalog;
            this.logger = logger;
        }
        public void Add(T entity)
        {
            logger.LogInformation("Entity added {T} : {value}", typeof(T).ToString(), JsonConvert.SerializeObject(entity));
            //code to add entity
            //perform action on dbContextCatalog
        }

        public void AddRange(IEnumerable<T> entities)
        {
            //code to add range of entities
            //perform action on dbContextCatalog
        }

        public void Delete(T entity)
        {
            logger.LogInformation("Entity deleted {T} : {value}", typeof(T).ToString(), JsonConvert.SerializeObject(entity));
            //code to delete entity
            //perform action on dbContextCatalog
        }

        public IQueryable<T> GetAll()
        {
            //code to get all entities
            //perform action on dbContextCatalog
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            //code to getEntity By Id
            //perform action on dbContextCatalog
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            //code to getEntity By Predicate
            //perform action on dbContextCatalog
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            logger.LogInformation("Entity updated {T} : {value}", typeof(T).ToString(), JsonConvert.SerializeObject(entity));
            //code to update entity
            //perform action on dbContextCatalog
        }
    }
}
