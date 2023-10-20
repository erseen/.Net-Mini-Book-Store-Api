using AutoMapper;
using Business.Abstract;
using Data.Dto;
using Data.Entities;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<BookDto>  CreateBookAsync(CreateBookDto createBookDto)
        {
           var book = _mapper.Map<Book>(createBookDto);

             await _manager.Book.AddAsync(book);
            return _mapper.Map<BookDto>(createBookDto);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _manager.Book.GetByIdAsync(id);

            if (book == null)
            {
                throw new Exception($"Book {id}can not find");
            }
           await _manager.Book.DeleteAsync(book);

        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _manager.Book.GetAllAsync();
            
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _manager.Book.GetByIdAsync(id);
            if (book == null)
            {
                throw new Exception($"Book {id} not found");
            }
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var entity = await _manager.Book.GetByIdAsync(updateBookDto.Id);
            if (entity == null)
                {
                    throw new Exception($"Book {updateBookDto.Id} not found");
                }

            _mapper.Map(updateBookDto, entity);
                await _manager.Book.UpdateAsync(entity);
                return _mapper.Map<BookDto>(entity);
        }

    }
}
