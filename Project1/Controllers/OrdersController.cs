using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

namespace Project1.Controllers
{
    public class OrdersController : Controller
    {
        public IBurgerRepo Repo { get; }

        public OrdersController(IBurgerRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Orders
        public ActionResult Index([FromQuery]int storeId = 1)
        {
            
            return View();
        }

        //GET: Orders/Menu
        public ActionResult Menu()
        {
            IEnumerable<Inventory> menu = Repo.DisplayMenu(1);
            IEnumerable<ViewModels.Inventory> viewModels = menu.Select(m =>
            new ViewModels.Inventory
            {
                Id = m.Id,
                Product = m.Product,
                StoreId = m.StoreId,
                Price = m.Price,
                IsSelected = false
            });

            return View(viewModels);
        }

        // POST: Orders/Menu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Menu([FromForm] int id, IFormCollection formCollection, IEnumerable<ViewModels.Inventory> products)
        {
            try
            {
                var order = Repo.GetCurrentOrder();
                //foreach (var item in products)
                //{
                    Repo.AddToOrder(order.Id, id);
                //}
                //return RedirectToAction(nameof(FinishOrder));
                return View("Added to your Order");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult AddToOrder( int id )
        {
            try
            {
                var order = Repo.GetCurrentOrder();
                //foreach (var item in products)
                //{
                Repo.AddToOrder(order.Id, id);
                //}
                //return RedirectToAction(nameof(FinishOrder));
                return RedirectToAction(nameof(Menu));
            }
            catch
            {
                return View("Error. Please try again.");
            }
        }

        // GET: Orders/Details/5
        public ActionResult CurrentOrderDetails()
        {
            CurrentOrder order = Repo.GetCurrentOrder();
            var viewModel = new ViewModels.CurrentOrder
            {
                OrderId = order.OrderId.Value,
                CustomerName = order.CustomerName,
                Location = order.Location,
                Order = order.Order,
                TotalPrice = order.TotalPrice,
            };

            return View(viewModel);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.CurrentOrder viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var order = new CurrentOrder
                    {
                        OrderId = viewModel.OrderId.Value,
                        CustomerName = viewModel.CustomerName,
                        CustomerId = viewModel.CustomerId,
                        Location = viewModel.Location,
                        StoreId = viewModel.StoreId,
                        Order = viewModel.Order,
                        TotalPrice = viewModel.TotalPrice,
                    };

                    Repo.BeginOrder(order);
                    Repo.Save();

                    return RedirectToAction(nameof(Menu));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        

        //GET: Order/FinishOrder/5
        public ActionResult FinishOrder()
        {
            CurrentOrder order = Repo.GetCurrentOrder();
            var viewModel = new ViewModels.CurrentOrder
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Location = order.Location,
                Order = order.Order,
                TotalPrice = order.TotalPrice,
            };
            return View(viewModel);
        }

        //POST: Order/FinishOrder/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinishOrder(int  id)
        {
            try
            {
                CurrentOrder entity = Repo.GetCurrentOrder();
                var newEntity = new Domain.Models.OrderHistory
                {
                    //OrderId = entity.OrderId.Value,
                    CustomerName = entity.CustomerName,
                    CustomerId = entity.CustomerId.Value,
                    Location = entity.Location,
                    StoreId = entity.StoreId.Value,
                    Order = entity.Order,
                    TotalPrice = entity.TotalPrice,
                    //DateTime = DateTime.Now
                };
                
                Repo.AddOrder(newEntity);
                //Repo.DecrementInventory();
                Repo.RemoveCurrentOrder();
                //Repo.Save();

                return RedirectToAction(nameof(Menu));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    OrderHistory order = Repo.g;
        //    var viewModel = new Models.Customer
        //    {
        //        Id = cust.Id,
        //        FirstName = cust.FirstName,
        //        LastName = cust.LastName,
        //        Address = cust.Address,
        //        PhoneNumber = cust.PhoneNumber
        //    };
        //    return View(viewModel);
        //}

        //// POST: Order/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        //{
        //    try
        //    {
        //        Repo.DeleteCustomer(id);
        //        Repo.Save();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult StoreHistory(int storeId)
        {
            storeId = int.Parse(TempData["StoreId"].ToString());
            IEnumerable<OrderHistory> items = Repo.OrderHistoryByCustomerId(storeId);
            IEnumerable<ViewModels.OrderHistory> orders = items.Select(s =>
            new ViewModels.OrderHistory
            {
                OrderId = s.OrderId,
                CustomerName = s.CustomerName,
                CustomerId = s.CustomerId,
                Location = s.Location,
                StoreId = s.StoreId,
                DateTime = s.DateTime.Value,
                Order = s.Order,
                TotalPrice = s.TotalPrice
            });

            return View(orders);
        }

        //GET: Orders/CustomerHistory
        public ActionResult CustomerHistory()
        {
            int custId = int.Parse(TempData["CustomerId"].ToString());
            IEnumerable<OrderHistory> items = Repo.OrderHistoryByCustomerId(custId);
            IEnumerable<ViewModels.OrderHistory> orders = items. Select(s =>
            new ViewModels.OrderHistory
            {
                OrderId = s.OrderId,
                CustomerName = s.CustomerName,
                CustomerId = s.CustomerId,
                Location = s.Location,
                StoreId = s.StoreId,
                DateTime = s.DateTime.Value,
                Order = s.Order,
                TotalPrice = s.TotalPrice
            });

            return View(orders);
        }

    }
}
