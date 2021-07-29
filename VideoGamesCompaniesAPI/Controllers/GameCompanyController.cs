using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VideoGamesCompaniesAPI.Models;
using VideoGamesCompaniesAPI.Services;

namespace VideoGamesCompaniesAPI.Controllers
{
    [Route("api/[controller]")]
    // ApiController
    //  if (!ModelState.IsValid)
    //      return BadRequest(ModelState);
    [ApiController]
    [Authorize]
    public class GameCompanyController : ControllerBase
    {
        private readonly IGameCompanyService _gameCompanyService;

        public GameCompanyController(IGameCompanyService gameCompanyService)
        {
            _gameCompanyService = gameCompanyService;
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateGameCompanyDto dto, [FromRoute] int id)
        {
            _gameCompanyService.Update(id, dto, User);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "HasNationality")]
        public ActionResult Delete([FromRoute] int id)
        {
            _gameCompanyService.Delete(id, User);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<GameCompanyDto>> GetAll()
        {
            var restaurantsDtos = _gameCompanyService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AtLeast20Yo")]
        public ActionResult<GameCompanyDto> Get([FromRoute] int id)
        {
            var restauranat = _gameCompanyService.GetById(id);

            return Ok(restauranat);
        }

        [HttpPost]
        [Authorize(Roles = ("Admin,Manager"))]
        public ActionResult Post([FromBody] CreateGameCompanyDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _gameCompanyService.Create(dto, userId);

            return Created($"/api/gameCompany/{id}", null);
        }
    }
}
