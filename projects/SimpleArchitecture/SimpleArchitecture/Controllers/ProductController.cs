using NHibernate;
using NHibernate.Linq;
using SimpleArchitecture.Models;
using SimpleArchitecture.Utils;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SimpleArchitecture.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                return View(session.Query<ProductModel>().ToList());
            }
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                return View(session.Get<ProductModel>(id));
            }
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
            product.Id = Guid.NewGuid();

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(product);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return View(session.Get<ProductModel>(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(product);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return View(session.Get<ProductModel>(id));
            }
        }

        [HttpPost]
        public ActionResult Delete(ProductModel product)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(session.Get<ProductModel>(product.Id));
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return RedirectToAction("List");
        }
    }
}