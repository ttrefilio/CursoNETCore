using System;
using System.Collections.Generic;

namespace Projeto.Domain.Interfaces.Caching
{
    public interface IBaseCaching<TEntity>
        where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
