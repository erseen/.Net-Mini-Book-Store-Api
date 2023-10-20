using Data.Dto;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto bookDto);
        Task<BookDto> UpdateBookAsync(UpdateBookDto bookDto);
        Task DeleteBookAsync(int  id);
    }
}
