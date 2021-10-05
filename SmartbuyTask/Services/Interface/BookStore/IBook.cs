using BookStore.Dto.BookDto;
using BookStore.Helpers.Paginations;
using BookStore.Models;
using BookStore.Services.Interface.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interface.BookStore
{
   public interface IBook: IBaseService<Book>
    {
        Task<PagedList<BookListDto>> GetBookPagedList(PaginationParams paginationParams);
    }
}
