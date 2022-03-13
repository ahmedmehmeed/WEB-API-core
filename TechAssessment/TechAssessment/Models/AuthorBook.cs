


using System.ComponentModel.DataAnnotations.Schema;

namespace TechAssessment.Models
{
    public class AuthorBook
    {
        [ForeignKey("book")]
        public int Book_id { get; set; }
        [ForeignKey("author")]
        public int Author_id { get; set; }

        public virtual Author author { get; set; }
        public virtual Book book { get; set; }

    }
}

