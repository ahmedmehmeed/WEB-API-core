using System.Collections.Generic;

namespace TechAssessment.Models
{
    public class Book
    {
        public Book()
        {
            AuthorBook = new HashSet<AuthorBook>();

        }


        public int Id { get; set; }
        public string DateofPublication { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }


        public virtual ICollection<AuthorBook> AuthorBook { get; set; }

    }
}
