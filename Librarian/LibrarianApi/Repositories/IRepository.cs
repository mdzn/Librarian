using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.API.Repositories
{
  public interface IRepository<TEntity> : IDisposable
  {
    void Add(TEntity entity);
    void Update(TEntity entity);
    IQueryable<TEntity> GetAll();
    TEntity Delete(int entity);
    TEntity Find(int id);
    bool Exists(int id);
  }
}