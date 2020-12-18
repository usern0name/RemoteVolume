using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemoteVolume.Business;

namespace RemoteVolume.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVolumeManager _volumeManager;

        public HomeController(IVolumeManager volumeManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _volumeManager = volumeManager;
        }

        [HttpGet]
        public object Get()
        {
            var result = this._volumeManager.GetCurrentSettings();
            return null;
        }
    }
}
