using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryShop.Core.Models;
using MilitaryShop.DataAccess.InMemory;
using MilitaryShop.Core.ViewModels;
using MilitaryShop.Core.Contracts;

namespace MilitaryShop.WebUI.Controllers
{
    public class ProductMenagerController : Controller
    {
        IRepository<Product> productRepository;
        IRepository<ProductCategory> productCategories;

        public ProductMenagerController(IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository)
        {
            this.productRepository = productRepository;
            productCategories = productCategoryRepository;
        }

        // GET: ProductMenager
        public ActionResult Index()
        {
            List<Product> products = productRepository.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductMenagerViewModel viewModel = new ProductMenagerViewModel();

            viewModel.Product = new Product();
            viewModel.productCategories = productCategories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                productRepository.Insert(product);
                productRepository.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = productRepository.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductMenagerViewModel viewModel = new ProductMenagerViewModel();
                viewModel.Product = new Product();
                viewModel.productCategories = productCategories.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = productRepository.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                productRepository.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = productRepository.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = productRepository.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                productRepository.Delete(Id);
                productRepository.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}