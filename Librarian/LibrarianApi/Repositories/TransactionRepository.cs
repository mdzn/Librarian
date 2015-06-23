using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Librarian.API.Models;
using Librarian.Entities;

namespace Librarian.API.Repositories
{
  public class TransactionRepository : IRepository<Transaction>
  {
    private LibrarianContext _dbContext;
    public TransactionRepository()
    {
      _dbContext = new LibrarianContext();
    }

    public void Add(Transaction entity)
    {
      _dbContext.Transactions.Add(entity); 
      _dbContext.SaveChanges();
    }

    public void Update(Transaction entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public IQueryable<Transaction> GetAll()
    {
      return _dbContext.Transactions;
    }

    public Transaction Delete(int id)
    {
      var transaction = _dbContext.Transactions.Find(id);
      if (transaction == null)
        return null;

      _dbContext.Transactions.Remove(transaction);
      _dbContext.SaveChanges();
      return transaction;
    }

    public Transaction Find(int id)
    {
      return _dbContext.Transactions.Find(id);
    }

    public bool Exists(int id)
    {
      return _dbContext.Transactions.Find(id) != null;
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }
  }
}