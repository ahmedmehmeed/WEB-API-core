using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechAssessment.DataAcessLayer;
using TechAssessment.Models;
using TechAssessment.ViewModels;

namespace TechAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IWebHostEnvironment hostEnvironment;

        public AuthorController(IAuthorRepository authorRepository, IWebHostEnvironment hostEnvironment)
        {
            this.authorRepository = authorRepository;
            this.hostEnvironment = hostEnvironment;
        }




        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(authorRepository.GetAll());
        }



        // GET api/<AuthorController>/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = authorRepository.GetById(id);
            if (author == null)
                return NotFound();

            else
                return Ok(author);


        }






        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuthorViewModel authorViewModel)
        {

            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(authorViewModel.Image.FileName);
                string extension = Path.GetExtension(authorViewModel.Image.FileName);
                authorViewModel.BookImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(hostEnvironment.ContentRootPath + "/Resources/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await authorViewModel.Image.CopyToAsync(fileStream);
                }

                authorRepository.Add(authorViewModel);
                return Ok(authorViewModel);

            }

            return BadRequest(authorViewModel);

        }






        //PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(authorViewModel.Image.FileName);
                string extension = Path.GetExtension(authorViewModel.Image.FileName);
                authorViewModel.BookImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                string path = Path.Combine(hostEnvironment.ContentRootPath + "/Resources/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await authorViewModel.Image.CopyToAsync(fileStream);
                }



                authorRepository.Update(id, authorViewModel);

                return Ok(authorViewModel);

            }


            return BadRequest(authorViewModel);
        }






        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            authorRepository.Delete(id);

        }

    }
}
