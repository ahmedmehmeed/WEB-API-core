using System.Collections.Generic;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.DataAcessLayer
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        Book GetById(int Id);
        Book GetByTitle(string title);
        void AddPLus(BookViewModel bookViewModel);
        void Update(int id, BookViewModel bookViewModel);
        void Delete(int id);


    }
}