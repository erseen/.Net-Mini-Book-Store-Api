using Data.RepoContext;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;

        public RepositoryManager(IBookRepository bookRepository, RepositoryContext context)
        {
            _bookRepository = bookRepository;
            _context = context;
        }

        public IBookRepository Book => _bookRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
