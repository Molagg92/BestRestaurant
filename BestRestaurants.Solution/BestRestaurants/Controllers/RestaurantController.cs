using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class RestaurantController: Controller
     {
        private readonly BestRestaurantsContext _db;

      public RestaurantController(BestRestaurantsContext db) 
       {
         _db = db;
       }
               
      public ActionResult Index()
      {
        List<Restaurant> model = _db.Restaurants.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
            var cuisines = _db.Cuisines.Select(cuisine => new SelectListItem 
            {
                Value = cuisine.CuisineId.ToString(), 
                Text = cuisine.Type
            })
                .ToList();
        
            ViewBag.Cuisines = cuisines;
        return View();
      }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
      } 

    }
