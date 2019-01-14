using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("company/[controller]/[action]")]
        public string Phone()
        {
            return "0745175025";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }

    }
}
