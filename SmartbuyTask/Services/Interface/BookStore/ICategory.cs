using BookStore.Models;
using BookStore.Services.Interface.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interface.BookStore
{
   public interface ICategory : IBaseService<Category>
    {
    }
}
