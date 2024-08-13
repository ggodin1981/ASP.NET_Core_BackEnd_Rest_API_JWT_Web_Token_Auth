using BookCatalog.Data.Entities; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Data.Model;
namespace BookCatalog.Data.Repository.Contract
{
    public interface ILibraryRepository
    {
        IQueryable<BookDTO> GetAll();
        Task<BookDetailDTO> GetBook(long bookid);
        Task<BookDetailDTO> GetBookName(string name);
        Task Insert(Book book);
        Task Update(Book book);
        Book Delete(long id);
        bool BookExists(long id);
    }
}
