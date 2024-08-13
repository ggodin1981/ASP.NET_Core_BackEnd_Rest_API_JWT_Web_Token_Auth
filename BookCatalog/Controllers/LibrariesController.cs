using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookCatalog.Data.Repository.Implementation;
using BookCatalog.Data.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using BookCatalog.Data.Entities;
using BookCatalog.Data;
using BookCatalog.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookCatalog.Controllers
{
    [Authorize]
    [Route("api/Libraries")]
    [ApiController]
    public class LibrariesController : Controller
    {
        private readonly LibraryRepository _libraryRepository;        
        public IConfiguration _configuration;
        private readonly LibraryContext _context;

        public LibrariesController(IConfiguration config, LibraryContext context)
        {
            _configuration = config;
            _context = context;
            _libraryRepository = new LibraryRepository(context);
        }       

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var authors = _libraryRepository.GetAll();
            return Ok(authors);
        }

        [HttpGet]
        [Route("GetBook")]
        public async Task<IActionResult> GetBook(long id)
        {
            try
            {
                var book = await _libraryRepository.GetBook(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                //log exception 
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetBookName")]
        public async Task<IActionResult> GetBookName(string name)
        {
            try
            {
                var author = await _libraryRepository.GetBookName(name);
                return Ok(author);
            }
            catch (Exception ex)
            {
                //log exception 
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("PutBook")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != book.Id)
            {
                return BadRequest();
            }           
            try
            {
                await _libraryRepository.Update(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_libraryRepository.BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("PostBook")]
        public async Task<IActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _libraryRepository.Insert(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }
       
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(long id)
        {
            Book book = null;
            try
            {
                book = _libraryRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }            
            return Ok(book);
        }
    }
}