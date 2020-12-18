using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AutoMapper;
using RemoteVolume.Data.Data;
using RemoteVolume.Data.Exception;

namespace RemoteVolume.Business.Impl
{
    public class VolumeManager : IVolumeManager
    {

        private readonly CoreAudioController _deviceController = new CoreAudioController();

        private static readonly IMapper MapperInstance = BuildMapper();

        public async Task<DeviceModel> GetDefaultDevice()
        {
            var defaultDevice = _deviceController.DefaultPlaybackDevice;
            var model = MapperInstance.Map<DeviceModel>(defaultDevice);

            return await Task.FromResult(model);
        }

        public async Task<DeviceModel> SetVolume(Guid deviceId, double volume)
        {
            var device = await _deviceController.GetDeviceAsync(deviceId);
            if (device == null)
            {
                //todo make ObjectNotFoundException
                throw new ExecutionException("device was not found");
            }

            await device.SetVolumeAsync(volume);

            var model = MapperInstance.Map<DeviceModel>(device);
            return model;
        }

        private static Mapper BuildMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CoreAudioDevice, DeviceModel>()
                    .ForMember(m => m.DeviceName, opt => opt.MapFrom(c => c.FullName))
                    .ForMember(m => m.InterfaceName, opt => opt.MapFrom(c => c.InterfaceName))
                    .ForMember(m => m.DeviceId, opt => opt.MapFrom(c => c.Id))
                    .ForMember(m => m.Volume, opt => opt.MapFrom(c => c.Volume));

            });
            return new Mapper(configuration);
        }
    }
}
