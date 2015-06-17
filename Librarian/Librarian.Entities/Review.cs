using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Entities
{
  public class Review
  {
    public int Id { get; set; }

    [DisplayName("Review")]
    public string Content { get; set; }
    public int Rating { get; set; }
    public string UserId { get; set; } //use the email value

    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }
    public int BookId { get; set; }
  }
}
