using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientStore _clientStore;
        private readonly IConfigurationDbContext _context;
        private readonly ILogger _logger;
        public HomeController(IConfigurationDbContext  configurationDbContext, ILogger<HomeController> logger)
        {
            _context = configurationDbContext;
            _logger = logger;
        }
        public async  Task<IActionResult> Index()
        {
            var client = _context.Clients
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.Properties)
                .AsNoTracking()
                .FirstOrDefault(x => x.ClientId == "IoTClient");
            var vm = client?.ToModel();
            return View(vm);
        } 
    }
}
