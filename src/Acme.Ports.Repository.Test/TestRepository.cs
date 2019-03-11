using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Core.Kernal;
using Acme.Core.Ports;

namespace Acme.Adapters.Repository.Test
{
    public class TestRepository : IRepository
    {
        public IList<Entity> TestEntities { get; set; }

        public TestRepository()
        {
            TestEntities = new List<Entity>();
        }


        public Task Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            TestEntities.Add(entity);
            return Task.CompletedTask;
        }

        public Task<TEntity> GetById<TEntity>(Guid id) where TEntity : Entity
        {
            var entity = TestEntities.FirstOrDefault(x => x.Id == id) as TEntity;
            return Task.FromResult(entity);
        }

        public Task<IList<TEntity>> List<TEntity>() where TEntity : Entity
        {
            IList<TEntity> entities = TestEntities.OfType<TEntity>().ToList();
            return Task.FromResult(entities);
        }
    }
}
