using Microsoft.AspNetCore.Http;

namespace TechAssessment.ViewModels
{
    public class AuthorViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string DoB { get; set; }
        public string bio { get; set; }
        public IFormFile Image { get; set; }
        public string BookImage { get; set; }
    }
}
