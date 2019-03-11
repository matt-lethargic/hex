using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Core.Kernal;

namespace Acme.Core.Ports
{
    public interface IRepository 
    {
        Task Save<TEntity>(TEntity entity) where TEntity : Entity;
        Task<TEntity> GetById<TEntity>(Guid id) where TEntity : Entity;
        Task<IList<TEntity>> List<TEntity>() where TEntity : Entity;
    }
}
