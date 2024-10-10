using API_EFCore.BLL.Interfaces;
using API_EFCore.DAL.Entities;
using API_EFCore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EFCore.BLL.Services
{
    public class BookBLLService : IBookBLLRepository
    {
        private readonly IBookRepository _repository;

        public BookBLLService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookEntity> GetBookByIdAsync(int id)
        {
            return await _repository.GetBookByIdAsync(id);
        }

        public async Task<IEnumerable<BookEntity>> GetBooksAsync()
        {
            return await _repository.GetBooksAsync();
        }
    }
}
