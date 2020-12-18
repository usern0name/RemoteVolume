using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteVolume.Data.Data
{
    public class DeviceModel
    {
        public string DeviceName { get; set; }

        public string InterfaceName { get; set; }

        public Guid DeviceId { get; set; }

        public double Volume { get; set; }
    }
}
