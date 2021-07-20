using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public interface IGameCompanyService
    {
        int Create(CreateGameCompanyDto dto);
        void Delete(int id);
        IEnumerable<GameCompanyDto> GetAll();
        GameCompanyDto GetById(int id);
        void Update(int id, UpdateGameCompanyDto dto);
    }

    public class GameCompanyService : IGameCompanyService
    {
        private readonly GameCompanyDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GameCompanyService> _logger;

        public GameCompanyService(GameCompanyDbContext dbContext, IMapper mapper, ILogger<GameCompanyService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Update(int id, UpdateGameCompanyDto dto)
        {
            var gameCompany = _dbContext
                .GameCompanies
                .FirstOrDefault(gc => gc.Id == id);

            if (gameCompany is null)
                throw new NotFoundException("Game company not found");

            gameCompany.Name = dto.Name;
            gameCompany.Description = dto.Description;
            gameCompany.CEO = dto.CEO;

            _dbContext.SaveChanges();
        }

        public GameCompanyDto GetById(int id)
        {
            var gameCompany = _dbContext
                .GameCompanies
                .Include(gc => gc.HqAddress)
                .Include(gc => gc.Games)
                .FirstOrDefault(gc => gc.Id == id);

            if (gameCompany is null)
                throw new NotFoundException("Game company not found");


            var result = _mapper.Map<GameCompanyDto>(gameCompany);
            return result;
        }

        public IEnumerable<GameCompanyDto> GetAll()
        {
            var gameCompanies = _dbContext
                .GameCompanies
                .Include(gc => gc.HqAddress)
                .Include(gc => gc.Games)
                .ToList();

            var results = _mapper.Map<List<GameCompanyDto>>(gameCompanies);
            return results;
        }

        public int Create(CreateGameCompanyDto dto)
        {
            var gameCompany = _mapper.Map<GameCompany>(dto);
            _dbContext.GameCompanies.Add(gameCompany);
            _dbContext.SaveChanges();

            return gameCompany.Id;
        }

        public void Delete(int id)
        {
            var gameCompany = _dbContext
                .GameCompanies
                .FirstOrDefault(gc => gc.Id == id);

            if (gameCompany is null)
                throw new NotFoundException("Game company not found");


            _dbContext.GameCompanies.Remove(gameCompany);
            _dbContext.SaveChanges();
        }
    }
}
