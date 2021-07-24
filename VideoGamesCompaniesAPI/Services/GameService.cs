using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesCompaniesAPI.Entities;
using VideoGamesCompaniesAPI.Exceptions;
using VideoGamesCompaniesAPI.Models;

namespace VideoGamesCompaniesAPI.Services
{
    public interface IGameService
    {
        int Create(int gameCompanyId, CreateGameDto dto);
        void DeleteAll(int gameCompanyId);
        IEnumerable<GameDto> GetAll(int gameCompanyId);
        GameDto GetById(int gameCompanyId, int gameId);
    }

    public class GameService : IGameService
    {
        private readonly GameCompanyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GameService(GameCompanyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int gameCompanyId, CreateGameDto dto)
        {
            var gameCompany = GetGameCompanyById(gameCompanyId);

            var game = _mapper.Map<Game>(dto);
            game.GameCompanyId = gameCompanyId;

            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game.Id;
        }

        public void DeleteAll(int gameCompanyId)
        {
            var gameCompany = GetGameCompanyById(gameCompanyId);

            _dbContext.RemoveRange(gameCompany.Games);
            _dbContext.SaveChanges();
        }

        public IEnumerable<GameDto> GetAll(int gameCompanyId)
        {
            var gameCompany = GetGameCompanyById(gameCompanyId);
            var gameDtos = _mapper.Map<List<GameDto>>(gameCompany.Games);

            return gameDtos;
        }

        public GameDto GetById(int gameCompanyId, int gameId)
        {
            var gameCompany = GetGameCompanyById(gameCompanyId);
            var game = _dbContext
                .Games
                .FirstOrDefault(g => g.Id == gameId);

            if (game is null || game.GameCompanyId != gameCompanyId)
            {
                throw new NotFoundException("Game is not found");
            }

            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }

        private GameCompany GetGameCompanyById(int id)
        {
            var gameCompany = _dbContext
                .GameCompanies
                .Include(gc => gc.Games)
                .FirstOrDefault(gc => gc.Id == id);

            if (gameCompany is null)
            {
                throw new NotFoundException("Game company not found");
            }

            return gameCompany;
        }
    }
}
