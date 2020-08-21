using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FakeLernMomentServer.Controllers
{
    [ApiController]
    [Route("lernmoment")]
    public class FakeLernMomentServerController : ControllerBase
    {
        private readonly ILogger<FakeLernMomentServerController> _logger;
        private IMemoryCache _cache;

        public FakeLernMomentServerController(ILogger<FakeLernMomentServerController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public string Get()
        {
            var lernMomentIndexSite = _cache.Get<String>("lernMomentIndexSite");

            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} - This is a slow server. Please wait while we prepare for serving ...");
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} - Now we waited long enough. It's time to rock and roll!");

            return lernMomentIndexSite;
        }
    }
}
