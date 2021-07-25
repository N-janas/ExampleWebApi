using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesCompaniesAPI.Entities;

namespace VideoGamesCompaniesAPI
{
    public class GameCompanySeeder
    {
        private readonly GameCompanyDbContext _dbContext;

        public GameCompanySeeder(GameCompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.GameCompanies.Any())
                {
                    var gameCompanies = GetGameCompanies();
                    _dbContext.GameCompanies.AddRange(gameCompanies);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Adnimistrator"
                }
            };

            return roles;
        }

        private IEnumerable<GameCompany> GetGameCompanies()
        {
            var gameCompanies = new List<GameCompany>()
            {
                new GameCompany()
                {
                    Name = "Rockstar Games",
                    Description = "This company has its headquarters in New York, USA and is owned by Take-Two Interactive. It was founded more than 20 years ago in 1998 by Sam House, Dan Houser, Terry Donovan, Jamie King, and Gary Foreman.",
                    CEO = "Sam Houser",
                    ContactEmail = "contact@rockstar.com",
                    HqAddress = new HqAddress()
                    {
                        City = "New York City",
                        Street = "622 Broadway",
                        PostalCode = "10012"
                    },
                    Games = new List<Game>()
                    {
                        new Game()
                        {
                            Name = "Grand Theft Auto",
                            Genre = "Sandbox",
                            Price = 40.90M
                        },
                        new Game()
                        {
                            Name = "Red Dead Redemption",
                            Genre = "Western",
                            Price = 210.29M
                        }
                    }

                },
                new GameCompany()
                {
                    Name = "Valve Corporation",
                    Description = "It’s headquartered in Bellevue, Washington and has a subsidiary in Luxembourg. It was started in 1996 by former Microsoft employees Gabe Newell and Mike Harrington. It has total equity of over USD2.5 Billion.",
                    CEO = "Gabe Newell",
                    ContactEmail = "contact@rockstar.com",
                    HqAddress = new HqAddress()
                    {
                        City = "Bellevue, WA",
                        Street = "Northeast Fourth Street",
                        PostalCode = "10400"
                    },
                    Games = new List<Game>()
                    {
                        new Game()
                        {
                            Name = "Counter Strike",
                            Genre = "FPS",
                            Price = 13.20M
                        },
                        new Game()
                        {
                            Name = "Half-Life",
                            Genre = "FPS",
                            Price = 9.99M
                        }
                    }
                }
            };

            return gameCompanies;
        }
    }
}
