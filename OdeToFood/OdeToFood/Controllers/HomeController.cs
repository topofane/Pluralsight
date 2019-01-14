using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IMavenlinkSettings _mavenlinkSettings;

        public HomeController(IRestaurantData restaurantData,
            IMavenlinkSettings mavenlinkSettings)
        {
            _restaurantData = restaurantData;
            _mavenlinkSettings = mavenlinkSettings;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _mavenlinkSettings.Schema;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
