using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Models
{
    public class UpdateGameCompanyDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }
    }
}
