using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project1.Controllers
{
    public class StoreController : Controller
    {
        public IBurgerRepo Repo {get;}

        public StoreController(IBurgerRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Store
        public ActionResult Index([FromQuery]string search ="")
        {
            IEnumerable<Store> stores = Repo.GetStores(search);
            IEnumerable<ViewModels.Store> viewModel = stores.Select(s => new ViewModels.Store
            {
                StoreId = s.StoreId,
                Location = s.Location,
                PhoneNumber = s.PhoneNumber
            });
            
            return View(viewModel);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            Store store = Repo.GetStoreById(id);
            var viewModel = new ViewModels.Store
            {
                StoreId = store.StoreId,
                Location = store.Location,
                PhoneNumber = store.PhoneNumber
            };
            TempData["StoreId"] = store.StoreId;
            return View(viewModel);
        }

        // POST: Store/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, IFormCollection collection)
        {
            try
            {
                Store store = Repo.GetStoreById(id);
                CurrentOrder order = Repo.GetCurrentOrder();

                order.Location = store.Location;
                order.StoreId = store.StoreId;
                Repo.AddStoreToOrder(order);
                //Repo.Save();

                return RedirectToAction("Menu", "Orders", id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Store viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var store = new Store
                    {
                        Location = viewModel.Location,
                        PhoneNumber = viewModel.PhoneNumber
                    };
                    Repo.AddStore(store);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            Store store = Repo.GetStoreById(id);
            var viewModel = new ViewModels.Store
            {
                StoreId = store.StoreId,
                Location = store.Location,
                PhoneNumber = store.PhoneNumber
            };
            return View(viewModel);
        }

        // POST: Store/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModels.Store viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Store store = Repo.GetStoreById(id);
                    store.Location = viewModel.Location;
                    Repo.UpdateStore(store);
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            Store store = Repo.GetStoreById(id);
            var viewModel = new ViewModels.Store
            {
                StoreId = store.StoreId,
                Location = store.Location,
                PhoneNumber = store.PhoneNumber
            };
            return View(viewModel);
        }

        // POST: Store/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                Repo.DeleteStore(id);
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