using API_EFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EFCore.BLL.Interfaces
{
    public interface IBookBLLRepository
    {
        Task<IEnumerable<BookEntity>> GetBooksAsync();
    }
}
