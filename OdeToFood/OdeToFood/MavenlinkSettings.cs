using Microsoft.Extensions.Configuration;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood
{
    public class MavenlinkSettings : IMavenlinkSettings
    {
        private IConfiguration _configuration;

        public MavenlinkSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Schema
        {
            get
            {
                return _configuration["MavenlinkSchema"];
}
        }
    }
}
