using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RemoteVolume.Business.Impl;

namespace RemoteVolume.Business.Configuration
{
    public static class BusinessServiceRegestrator
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IVolumeManager, VolumeManager>();
        }
    }
}
