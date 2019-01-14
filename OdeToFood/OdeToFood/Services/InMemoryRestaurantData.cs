﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1 , Name = "Maya Fresh" },
                new Restaurant {Id = 2, Name = "La Baiatu"},
                new Restaurant {Id = 3, Name = "The Harbour" }
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(x => x.Name);
        }
    }
}
