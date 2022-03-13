using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.DataAcessLayer
{
    public class BookRepository : IBookRepository
    {
        private readonly AssessmentContext context;

        public BookRepository(AssessmentContext _Context)
        {
            context = _Context;
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();

        }

        public Book GetById(int Id)
        {
            return context.Books.FirstOrDefault(e => e.Id == Id);

        }

        //search bar
        public Book GetByTitle(string title)
        {
            return context.Books.FirstOrDefault(e => e.Title == title);

        }

        public void AddPLus(BookViewModel bookViewModel)
        {

            Book book = new Book();
            book.DateofPublication = bookViewModel.DateofPublication;
            book.Cover = bookViewModel.BookImage;
            book.Description = bookViewModel.Description;
            book.Title = bookViewModel.Title;
            foreach (var item in bookViewModel.AuthorBook)
            {
                book.AuthorBook.Add(new AuthorBook()
                {
                    Author_id = item.Author_id

                });

            }

            context.Add(book);
            context.SaveChanges();
        }




        public void Update(int id, BookViewModel bookViewModel)
        {

            Book OldBook = context.Books.FirstOrDefault(e => e.Id == id);

            OldBook.DateofPublication = bookViewModel.DateofPublication;
            OldBook.Cover = bookViewModel.BookImage;
            OldBook.Description = bookViewModel.Description;
            OldBook.Title = bookViewModel.Title;

            List<AuthorBook> Newlist = new List<AuthorBook>();


            foreach (var item in bookViewModel.AuthorBook)
            {
                Newlist.Add(new AuthorBook()
                {
                    Author_id = item.Author_id
                }
                );
            }

            OldBook.AuthorBook.Clear();
            OldBook.AuthorBook = Newlist;

            context.SaveChanges();

        }



        public void Delete(int id)
        {
            Book OldBook = context.Books.FirstOrDefault(e => e.Id == id);
            context.Remove(OldBook);
            context.SaveChanges();

        }


    }
}