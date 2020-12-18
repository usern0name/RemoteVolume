using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RemoteVolume.Data.Data;

namespace RemoteVolume.Business
{
    public interface IVolumeManager
    {
        Task<DeviceModel> GetDefaultDevice();

        Task<DeviceModel> SetVolume(Guid deviceId, double volume);
    }
}
