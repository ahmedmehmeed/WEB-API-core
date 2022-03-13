using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TechAssessment.Models;

namespace TechAssessment.ViewModels
{
    public class BookViewModel
    {


        public int Id { get; set; }
        public string DateofPublication { get; set; }
        public IFormFile BookCover { get; set; }
        public string BookImage { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AuthorBook> AuthorBook { get; set; }


    }
}
