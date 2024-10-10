using API_EFCore.DAL.Entities;
using API_EFCore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EFCore.DAL.DataAccess
{
    public class BookService : IBookRepository
    {
        private readonly MyDbContext _context;

        public BookService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<BookEntity> GetBookByIdAsync(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BookEntity>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
