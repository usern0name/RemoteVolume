using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemoteVolume.Api.Models;
using RemoteVolume.Business;
using RemoteVolume.Data.Data;

namespace RemoteVolume.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolumeController : ControllerBase
    {
        private readonly ILogger<VolumeController> _logger;

        private readonly IVolumeManager _volumeManager;

        public VolumeController(IVolumeManager volumeManager, ILogger<VolumeController> logger)
        {
            _logger = logger;
            _volumeManager = volumeManager;
        }

        [HttpGet]
        public async Task<DeviceModel> Get()
        {
            var result = await this._volumeManager.GetDefaultDevice();
            return result;
        }

        [HttpPut]
        public async Task<DeviceModel> Put(VolumeModel model)
        {
            var result = await this._volumeManager.SetVolume(model.DeviceId, model.Volume);
            return result;
        }
    }
}
