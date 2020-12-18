using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteVolume.Api.Models
{
    public class VolumeModel
    {
        public Guid DeviceId { get; set; }

        public double Volume { get; set; }
    }
}
