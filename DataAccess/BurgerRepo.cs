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

        public IEnumerable<Domain.Models.Store> GetStores(string search = null)
        {
            IEnumerable<Entities.Stores> items = _dbContext.Stores
                .AsNoTracking();

            items = items.Where(s => s.Location.Contains(search)).AsEnumerable();

            IEnumerable<Domain.Models.Store> newItems = items.Select(s =>
            new Store
            {
                StoreId = s.StoreId,
                Location = s.Location,
                PhoneNumber = Int64.Parse(s.PhoneNumber)
            });

            return newItems;
        }

        public Store GetStoreById(int storeId)
        {
            Stores item = _dbContext.Stores
                .FirstOrDefault(s => s.StoreId == storeId);

            Store newItem = new Store
            {
                StoreId = item.StoreId,
                Location = item.Location,
                PhoneNumber = Int64.Parse(item.PhoneNumber)
            };

            return newItem;
        }

        public void AddCustomer(Customer cust)
        {
            if (cust.Id != 0)
            {
                _logger.LogWarning("Customer to be added has an ID ({custId}) already: ignoring.", cust.Id);
            }

            _logger.LogInformation("Adding customer");

            Customers entity = new Customers
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = cust.PhoneNumber.ToString()
            };

            entity.Id = 0;
            _dbContext.Add(entity);
        }

        public void DeleteCustomer(int custId)
        {
            _logger.LogInformation("Deleting customer with ID {custId}", custId);
            Customers entity = _dbContext.Customers.Find(custId);
            _dbContext.Remove(entity);
        }

        public void UpdateCustomer(Customer cust)
        {
            _logger.LogInformation("Updating customer with ID {custId}", cust.Id);

            Customers currentEntity = _dbContext.Customers.Find(cust.Id);
            Customers newEntity = new Customers
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = cust.PhoneNumber.ToString()
            };

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        public Customer GetCustomerById(int custId)
        {
            Customers cust = _dbContext.Customers.AsNoTracking()
                .First(c => c.Id == custId);

            Customer customer = new Customer
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = Int64.Parse(cust.PhoneNumber)
            };
            return customer;
        }

        public void AddOrder(Domain.Models.OrderHistory order)
        {
            if (order.OrderId != 0)
            {
                _logger.LogWarning("Order to be added has an ID ({orderId}) already: ignoring.", order.OrderId);
            }

            _logger.LogInformation("Placing order.");

            Entities.OrderHistory newEntity = new Entities.OrderHistory
            {
                CustomerName = order.CustomerName,
                CustomerId = order.CustomerId,
                Location = order.Location,
                StoreId = order.StoreId,
                DateTime = order.DateTime,
                Order = order.Order,
                TotalPrice = order.TotalPrice
            };

            _dbContext.Add(newEntity);
        }

        public void DeleteOrder(int orderId)
        {
            _logger.LogInformation("Deleting order with ID {orderId}", orderId);

            Entities.OrderHistory entity = _dbContext.OrderHistory.Find(orderId);
            _dbContext.Remove(entity);
        }

        public void UpdateOrder(Domain.Models.OrderHistory order)
        {
            _logger.LogInformation("Updating order with ID {orderId}", order.OrderId);

            Entities.OrderHistory currentEntity = _dbContext.OrderHistory.Find(order.OrderId);
            Entities.OrderHistory newEntity = new Entities.OrderHistory
            {
                CustomerName = order.CustomerName,
                CustomerId = order.CustomerId,
                Location = order.Location,
                StoreId = order.StoreId,
                DateTime = order.DateTime,
                Order = order.Order,
                TotalPrice = order.TotalPrice
            };

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        public IEnumerable<Domain.Models.OrderHistory> OrderHistoryFromCustomerId(int custId)
        {
            IEnumerable<Entities.OrderHistory> items = _dbContext.OrderHistory
                .AsNoTracking();

            items = items.Where(o => o.CustomerId == custId).AsEnumerable();

            IEnumerable<Domain.Models.OrderHistory> newItems = items.Select(s =>
            new Domain.Models.OrderHistory
            {
                CustomerName = s.CustomerName,
                CustomerId = s.CustomerId,
                Location = s.Location,
                StoreId = s.StoreId,
                DateTime = s.DateTime,
                Order = s.Order,
                TotalPrice = s.TotalPrice
            });

            return newItems;
        }

        public IEnumerable<Domain.Models.OrderHistory> OrderHistoryFromStoreId(int storeId)
        {
            IEnumerable<Entities.OrderHistory> items = _dbContext.OrderHistory
                .AsNoTracking();

            items = items.Where(o => o.StoreId == storeId).AsEnumerable();

            IEnumerable<Domain.Models.OrderHistory> newItems = items.Select(s =>
            new Domain.Models.OrderHistory
            {
                CustomerName = s.CustomerName,
                CustomerId = s.CustomerId,
                Location = s.Location,
                StoreId = s.StoreId,
                DateTime = s.DateTime,
                Order = s.Order,
                TotalPrice = s.TotalPrice
            });

            return newItems;
        }

        public void Save()
        {
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}

