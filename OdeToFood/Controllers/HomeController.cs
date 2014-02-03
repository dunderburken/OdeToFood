using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{    
    public class HomeController : Controller
    {
        IOdeToFoodDb _db;
        public HomeController()
        {
            _db = new OdeToFoodDb();
        }

        public HomeController(IOdeToFoodDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Query<Restaurant>()
                .Where(r => r.Name.StartsWith(term))
                //.OrderBy(r => r.Reviews.Count())
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });
                return Json(model,JsonRequestBehavior.AllowGet);
        }        

        //[OutputCache(Duration=360,VaryByHeader="X-Requested-With",Location=OutputCacheLocation.Server)]
        [OutputCache(CacheProfile = "Mild")]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Query<Restaurant>()
                        .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                        .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                        .Select(r => new RestaurantListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfReviews = r.Reviews.Count()

                        }).ToPagedList(page,20);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants",model);
            }
            
            return View(model);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}