using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesCompaniesAPI.Models;
using VideoGamesCompaniesAPI.Services;

namespace VideoGamesCompaniesAPI.Controllers
{
    [Route("api/gameCompany")]
    // ApiController
    //  if (!ModelState.IsValid)
    //      return BadRequest(ModelState);
    [ApiController]
    public class GameCompanyController : ControllerBase
    {
        private readonly IGameCompanyService _gameCompanyService;

        public GameCompanyController(IGameCompanyService gameCompanyService)
        {
            _gameCompanyService = gameCompanyService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateGameCompanyDto dto, [FromRoute] int id)
        {
            _gameCompanyService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _gameCompanyService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameCompanyDto>> GetAll()
        {
            var restaurantsDtos = _gameCompanyService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<GameCompanyDto> Get([FromRoute] int id)
        {
            var restauranat = _gameCompanyService.GetById(id);

            return Ok(restauranat);
        }

        [HttpPost]
        public ActionResult CreateGameCompany([FromBody] CreateGameCompanyDto dto)
        {
            var id = _gameCompanyService.Create(dto);

            return Created($"/api/gameCompany/{id}", null);
        }
    }
}
