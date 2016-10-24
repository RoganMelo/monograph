using Domain.Product.Contracts;
using Domain.Product.Model;
using System;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService applicationService;

        public ProductController(IProductApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(applicationService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(applicationService.GetById(id));
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(ProductModel product)
        {
            applicationService.Create(product);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(applicationService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel product)
        {
            applicationService.Update(product);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(applicationService.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(ProductModel product)
        {
            applicationService.Delete(product.Id);

            return RedirectToAction("List");
        }
    }
}