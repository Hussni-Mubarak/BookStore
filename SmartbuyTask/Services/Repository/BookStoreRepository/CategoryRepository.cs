using BookStore.ApplictaionDbContext;
using BookStore.Models;
using BookStore.Services.Interface.BookStore;
using BookStore.Services.Repository.BaseServiceRepositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Repository.BookStoreRepository
{
    public class CategoryRepository : BaseServiceRepository<Category>, ICategory
    {
        private readonly DataContext _context;

    public CategoryRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
}
