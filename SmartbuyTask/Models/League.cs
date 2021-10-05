using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class League
    {
        public string LeagueCaption { get; set; }

        public IEnumerable<Standing> Standings { get; set; }
    }
}
