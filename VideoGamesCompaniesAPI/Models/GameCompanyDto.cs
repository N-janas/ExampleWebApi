using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Models
{
    public class GameCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<GameDto> Games { get; set; }
    }
}
