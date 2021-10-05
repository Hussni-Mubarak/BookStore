using BookStore.ApplictaionDbContext;
using BookStore.Dto.BookDto;
using BookStore.Helpers.Paginations;
using BookStore.Models;
using BookStore.Services.Interface.BookStore;
using BookStore.Services.Repository.BaseServiceRepositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Repository.BookStoreRepository
{
    public class BookRepository : BaseServiceRepository<Book>, IBook
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<BookListDto>> GetBookPagedList(PaginationParams paginationParams)
        {
     
            var book = _context.Books.OrderBy(x => x.Id)
                         .Select(p => new BookListDto()
                         {
                             CategoryId = p.CategoryId,
                             CategoryName = p.Category.CategoryName,
                             Title = p.Title,
                             Description=p.Description,
                             ReleaseDate=p.ReleaseDate,
                             AuthorId=p.AuthorId,
                                           });
            return await PagedList<BookListDto>.CreateAsync(book, paginationParams.PageNumber, paginationParams.PageSize);
        }
    }
}
