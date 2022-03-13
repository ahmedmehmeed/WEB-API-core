using System.Collections.Generic;

namespace TechAssessment.Models
{
    public class Author
    {
        public Author()
        {
            AuthorBook = new HashSet<AuthorBook>();   
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string DoB { get; set; }
        public string bio { get; set; }
        public string Image { get; set; }
        public virtual ICollection<AuthorBook> AuthorBook { get; set; }


    }

}
