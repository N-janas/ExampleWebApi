using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public int GameCompanyId { get; set; }
        public virtual GameCompany GameCompany { get; set; }
    }
}
