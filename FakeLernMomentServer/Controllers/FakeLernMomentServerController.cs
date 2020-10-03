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
        private IMemoryCache _cache;

        public FakeLernMomentServerController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{delayInSeconds}")]
        public async Task<ActionResult<string>> Get(int delayInSeconds)
        {
            var lernMomentIndexSite = _cache.Get<String>("lernMomentIndexSite");

            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} - This is a slow server. Please wait while we prepare for serving ...");
            int waitedSeconds = 0;
            while (delayInSeconds > waitedSeconds)
            {
                waitedSeconds++;
                await Task.Delay(TimeSpan.FromSeconds(1));
                Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} - Still preparing ...");
            }
            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} - Now we waited long enough. It's time to rock and roll!");

            return lernMomentIndexSite;
        }
    }
}
