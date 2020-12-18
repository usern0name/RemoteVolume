using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteVolume.Business
{
    public interface IVolumeManager
    {
        IEnumerable<object> GetCurrentSettings();
    }
}
