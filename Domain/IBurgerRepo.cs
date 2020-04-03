using Domain.Models;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// A repository managing data access for Customer, Order, Store, and Inventory objects.
    /// </summary>
    public interface IBurgerRepo
    {
        /// <summary>
        /// Get all stores with deferred execution.
        /// </summary>
        /// <returns>The collection of stores</returns>
        IEnumerable<Store> GetStores(string search = null);

        /// <summary>
        /// Get a store by ID.
        /// </summary>
        /// <returns>The store</returns>
        Store GetStoreById(int storeId);

        void AddStore(Store store);

        void DeleteStore(int storeId);

        void UpdateStore(Store store);

        /// <summary>
        /// Add a customer.
        /// </summary>
        /// <param name="cust">The customer</param>
        void AddCustomer(Customer cust);

        /// <summary>
        /// Delete a customer by ID. Any orders associated to it will also be deleted.
        /// </summary>
        /// <param int="custId">The ID of the customer</param>
        void DeleteCustomer(int custId);

        /// <summary>
        /// Update a customer's info.
        /// </summary>
        /// <param name="cust">The customer with changed values</param>
        void UpdateCustomer(Customer cust);

        /// <summary>
        /// Get a customer by ID.
        /// </summary>
        /// <param int="custId">The ID of the customer</param>
        Customer GetCustomerById(int custId);

        IEnumerable<Customer> GetCustomerByName(string search);


        /// <summary>
        /// Add an order and associate it with a restaurant and customer.
        /// </summary>
        /// <param name="order">The order</param>
        /// <param int="storeId">The store's Id #</param>
        /// <param int="custId">The customer's Id #</param>
        void AddOrder(OrderHistory order);

        /// <summary>
        /// Delete a review by ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        void DeleteOrder(int orderId);

        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="order">The order with changed values</param>
        void UpdateOrder(OrderHistory order);

        /// <summary>
        /// Get all orders according to customer Id.
        /// </summary>
        /// <param name="custId">The ID of the customer</param>
        /// <returns>The collection of restaurants</returns>
        IEnumerable<OrderHistory> OrderHistoryByCustomerId(int custId);

        /// <summary>
        /// Get all orders according to store Id.
        /// </summary>
        /// <param name="storeId">The ID of the store</param>
        /// <returns>The collection of restaurants</returns>
        IEnumerable<OrderHistory> OrderHistoryByStoreId(int storeId);

        void DecrementInventory(string product, int storeId);


        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();

    }
}
