using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.API.Models
{
  public class Transaction
  {
    public int Id { get; set; }

    [ForeignKey("LibraryBookId")]
    public virtual LibraryBook LibraryBook { get; set; }
    public int LibraryBookId { get; set; }

    public virtual TransactionType TransactionType { get; set; }
  }

  public enum TransactionType
  {
    CheckOut,
    CheckIn
  }
}