using DataAccess.Entities;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class BurgerRepo : IBurgerRepo
    {
        private readonly BurgerDbContext _dbContext;

        private readonly ILogger<BurgerRepo> _logger;

        public BurgerRepo(BurgerDbContext dbContext, ILogger<BurgerRepo> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        IEnumerable<Store> GetStores(string search = null)
        {
            IQueryable<Stores> items = _dbContext.Stores
                .AsNoTracking();
            if (search != null)
            {
                items = items.Where(s => s.Location.Contains(search));
            }
            return items.Select(s => new Store 
                {
                    StoreId = s.StoreId,
                    Location = s.Location,
                    PhoneNumber = s.PhoneNumber
                });
        }


    }
}
