using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interface.External
{
    public interface IRanking
    {
        Task<League> GetRanking(long id);
    }
}
