using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly ILogger _logger;
        public HomeController(IClientStore clientStore,ILogger<HomeController> logger)
        {
            _clientStore = clientStore;
            _logger = logger;
        }
        public async  Task<IActionResult> Index()
        {
            _logger.LogInformation("start");
            var vm=await _clientStore.FindClientByIdAsync("IoTClient");
            return View(vm);
        } 
    }
}
