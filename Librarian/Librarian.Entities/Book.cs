using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Librarian.Entities
{
  public class Book
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }
    public string Summary { get; set; }

    [Display(Name = "Published Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime PublishedDate { get; set; }

    public string ISBN { get; set; }

    [ForeignKey("AuthorId")]
    public virtual Author Author { get; set; }
    public int AuthorId { get; set; }

    [ForeignKey("BookPublisherId")]
    public virtual BookPublisher BookPublisher { get; set; }
    public int BookPublisherId { get; set; }

    public virtual IEnumerable<Review> Reviews { get; set; }
  }
}