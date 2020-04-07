using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Project1.Controllers
{
    public class CustomerController : Controller
    {
        public IBurgerRepo Repo { get; }

        public CustomerController(IBurgerRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Customer
        public ActionResult Index([FromQuery]string search = "")
        {
            //IEnumerable<Customer> cust = Repo.GetCustomerByFullName(search, search);
            //IEnumerable<ViewModels.Customer> viewModels = cust.Select(c => new ViewModels.Customer
            //{
            //    Id = c.Id,
            //    FirstName = c.FirstName,
            //    LastName = c.LastName,
            //    Address = c.Address,
            //    PhoneNumber = c.PhoneNumber
            //});

            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details([FromRoute]int id)
        {
            Customer cust = Repo.GetCustomerById(id);
            var viewModel = new ViewModels.Customer
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = cust.PhoneNumber
            };
            TempData["CustomerId"] = cust.Id;
            return View(viewModel);
        }

        // POST: Customer/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, IFormCollection collection)
        {
            try
            {
                Customer cust = Repo.GetCustomerById(id);
                CurrentOrder newOrder = new CurrentOrder
                {
                    CustomerName = cust.FirstName + " " + cust.LastName,
                    CustomerId = cust.Id
                };

                Repo.BeginOrder(newOrder);
                Repo.Save();

                return RedirectToAction("Index", "Store");
            }
            catch
            {
                return View();
            }
        }

            // GET: Customer/LoginCustomer
            public ActionResult LoginCustomer()
        {
            return View();
        }

        // POST: Customer/LoginCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCustomer([Bind("FirstName", "LastName")]ViewModels.Login viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string firstName = viewModel.FirstName;
                    string lastName = viewModel.LastName;

                    var cust = Repo.GetCustomerByFullName(firstName, lastName);
                    if(cust.FirstName == null)
                    {
                        return RedirectToAction(nameof(CustomerNotFound));
                    }

                    return RedirectToAction(nameof(Details), new { id = cust.Id });
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Customer/CustomerNotFound
        public ActionResult CustomerNotFound()
        {
            return View();
        }

        // GET: Customer/AddCustomer
        public ActionResult AddCustomer()
        {
            return View();
        }

        // POST: Customer/AddCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(ViewModels.Customer viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cust = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Address = viewModel.Address,
                        PhoneNumber = viewModel.PhoneNumber
                    };
                    Repo.AddCustomer(cust);
                    Repo.Save();

                    return RedirectToAction(nameof(LoginCustomer));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer cust = Repo.GetCustomerById(id);
            var viewModel = new ViewModels.Customer
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = cust.PhoneNumber
            };
            return View(viewModel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModels.Customer viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer cust = Repo.GetCustomerById(id);
                    cust.FirstName = viewModel.FirstName;
                    cust.LastName = viewModel.LastName;
                    cust.Address = viewModel.Address;
                    cust.PhoneNumber = viewModel.PhoneNumber;
                    Repo.UpdateCustomer(cust);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                return View(viewModel);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer cust = Repo.GetCustomerById(id);
            var viewModel = new ViewModels.Customer
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                PhoneNumber = cust.PhoneNumber
            };
            return View(viewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                Repo.DeleteCustomer(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}