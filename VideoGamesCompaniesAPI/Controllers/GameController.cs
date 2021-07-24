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
    [Route("api/gameCompany/{gameCompanyId}/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int gameCompanyId, [FromBody] CreateGameDto dto)
        {
            var id = _gameService.Create(gameCompanyId, dto);

            return Created($"api/gameCompany/{gameCompanyId}/game/{id}", null);
        }

        [HttpGet("{gameId}")]
        public ActionResult<GameDto> Get([FromRoute] int gameCompanyId, [FromRoute] int gameId)
        {
            var game = _gameService.GetById(gameCompanyId, gameId);

            return Ok(game);
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> GetAll([FromRoute] int gameCompanyId)
        {
            var games = _gameService.GetAll(gameCompanyId);

            return Ok(games);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int gameCompanyId)
        {
            _gameService.DeleteAll(gameCompanyId);

            return NoContent();
        }


    }
}
