using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.DataAcessLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AssessmentContext context;

        public AuthorRepository(AssessmentContext _Context)
        {
            context = _Context;
        }

        public List<Author> GetAll()
        {
            return context.Authors.ToList();

        }


        public Author GetById(int Id)
        {
            return context.Authors.FirstOrDefault(e=>e.Id ==Id);

        }



        public void Add(AuthorViewModel authorViewModel)
        { 
            Author author = new Author();
            author.Name = authorViewModel.Name;
            author.DoB=authorViewModel.DoB;
            author.Image=authorViewModel.BookImage;
            author.bio=authorViewModel.bio;

            context.Authors.Add(author);
            context.SaveChanges();
        }


        public void Update(int id, AuthorViewModel authorViewModel)
        {
            Author OldAuthor = context.Authors.FirstOrDefault(e => e.Id == id);
            OldAuthor.Name = authorViewModel.Name;
            OldAuthor.bio = authorViewModel.bio;
            OldAuthor.DoB = authorViewModel.DoB;
            OldAuthor.Image = authorViewModel.BookImage;

             context.SaveChanges();


        }




        public void Delete(int id)
        {
            Author OldAuthor = context.Authors.FirstOrDefault(e => e.Id == id);
            context.Remove(OldAuthor);
            context.SaveChanges();

        }
    }
}
