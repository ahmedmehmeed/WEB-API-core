using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechAssessment.DataAcessLayer;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase


    {
        private readonly IBookRepository bookRepository;
        private readonly IWebHostEnvironment hostEnvironment;

        public BooksController(IBookRepository bookRepository, IWebHostEnvironment hostEnvironment)
        {
            this.bookRepository = bookRepository;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bookRepository.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(bookRepository.GetById(id));
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            return Ok(bookRepository.GetByTitle(title));
        }


        [HttpPost]
        public async Task<IActionResult> AddPlus([FromBody] BookViewModel bookViewModel)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(bookViewModel.BookCover.FileName);
                string extension = Path.GetExtension(bookViewModel.BookCover.FileName);
                bookViewModel.BookImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(hostEnvironment.ContentRootPath + "/Resources/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await bookViewModel.BookCover.CopyToAsync(fileStream);
                }

                bookRepository.AddPLus(bookViewModel);
                return Ok(bookViewModel);

            }

            return BadRequest(bookViewModel);




        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookViewModel bookViewModel)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(bookViewModel.BookCover.FileName);
                string extension = Path.GetExtension(bookViewModel.BookCover.FileName);
                bookViewModel.BookImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(hostEnvironment.ContentRootPath + "/Resources/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await bookViewModel.BookCover.CopyToAsync(fileStream);
                }


                bookRepository.Update(id, bookViewModel);
                return Ok(bookViewModel);

            }

            return BadRequest(bookViewModel);

        }





        //DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookRepository.Delete(id);

        }
    }
}