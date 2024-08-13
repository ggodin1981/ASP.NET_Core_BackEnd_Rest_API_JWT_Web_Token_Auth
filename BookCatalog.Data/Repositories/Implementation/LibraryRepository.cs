using BookCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Data;
using BookCatalog.Data.Repository.Contract;
using BookCatalog.Model;
using BookCatalog;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.Data.SqlClient;
using AutoMapper;
using System.Net;
using BookCatalog.Data.Model;

namespace BookCatalog.Data.Repository.Implementation
{
    public class LibraryRepository: ILibraryRepository
    {
        readonly LibraryContext _libraryContext;        
        public LibraryRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IQueryable<BookDTO> GetAll()
        {
            try
            {
                var books = from b in _libraryContext.Book
                            select new BookDTO()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Description = b.Description,
                                PublishDateUtc = b.PublishDateUtc,
                                CategoryName = b.Category.Name
                            };
                return books;                
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }       
        }
        public async Task<BookDetailDTO> GetBook(long bookid)
        {
            try
            {
                return await _libraryContext.Book.Include(b => b.Category).Select(b =>
                            new BookDetailDTO()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Description = b.Description,
                                PublishDateUtc = b.PublishDateUtc,
                                CategoryName = b.Category.Name
                            }).SingleOrDefaultAsync(b => b.Id == bookid);
                
            }
            catch(Exception ex)
            {
                //log exception
                return null;
            }
        }
        public async Task<BookDetailDTO>  GetBookName(string name)
        {
            try
            {
                return await _libraryContext.Book.Include(b => b.Category).Select(b =>
                           new BookDetailDTO()
                           {
                               Id = b.Id,
                               Title = b.Title,
                               Description = b.Description,
                               PublishDateUtc = b.PublishDateUtc,
                               CategoryName = b.Category.Name
                           }).SingleOrDefaultAsync(b => b.Title.Contains(name));
            }
            catch (Exception ex)
            {                
                return null;
            }
        }
        public async Task Update(Book book)
        {
            try
            {
                _libraryContext.Entry(book).State = EntityState.Modified;
                await _libraryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
            }
        }
        public async Task Insert(Book book)
        {
            try
            {
                _libraryContext.Book.Add(book);
                await _libraryContext.SaveChangesAsync();                
            }
            catch (Exception ex)
            {
            }
        }
        public Book Delete(long id)
        {
            try
            {
                Book book = _libraryContext.Book.Find(id);
                if (book != null)
                {
                    _libraryContext.Book.Remove(book);
                    return book;
                }                        
            }
            catch (Exception ex)
            {}
            return null;
        }

        public bool BookExists(long id)
        {
            return _libraryContext.Book.Count(e => e.Id == id) > 0;
        }
    }
}
