using System.Collections.Generic;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.DataAcessLayer
{
    public interface IAuthorRepository
    {
          List<Author> GetAll();

          Author GetById(int Id);

          void   Add(AuthorViewModel authorViewModel);
          void Update(int id , AuthorViewModel authorViewModel);
          void Delete(int id);


    }
}