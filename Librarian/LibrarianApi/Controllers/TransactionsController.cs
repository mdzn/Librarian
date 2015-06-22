using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Librarian.API.Models;
using Librarian.API.Repositories;
using Librarian.Entities;

namespace Librarian.API.Controllers
{
  public class TransactionsController : ApiController
  {
    private IRepository<Transaction> _repo;
    public TransactionsController(IRepository<Transaction> repository)
    {
      _repo = repository;
    }

    // GET: api/Transactions
    public IQueryable<Transaction> GetTransactions()
    {
      return _repo.GetAll();
    }

    // GET: api/Transactions/5
    [ResponseType(typeof(Transaction))]
    public IHttpActionResult GetTransaction(int id)
    {
      var transaction = _repo.Find(id);
      if (transaction == null)
      {
        return NotFound();
      }

      return Ok(transaction);
    }

    // PUT: api/Transactions/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutTransaction(int id, Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != transaction.Id)
      {
        return BadRequest();
      }
      
      try
      {
        _repo.Update(transaction);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TransactionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Transactions
    [ResponseType(typeof(Transaction))]
    public IHttpActionResult PostTransaction(Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _repo.Add(transaction);
      return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _repo.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool TransactionExists(int id)
    {
      return _repo.Exists(id);
    }
  }
}