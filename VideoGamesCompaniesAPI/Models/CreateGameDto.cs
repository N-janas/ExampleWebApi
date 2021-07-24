using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Models
{
    public class CreateGameDto
    {
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
