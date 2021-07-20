using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Entities
{
    public class GameCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }
        public string ContactEmail { get; set; }

        public int HqAddressId { get; set; }
        public virtual HqAddress HqAddress { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
