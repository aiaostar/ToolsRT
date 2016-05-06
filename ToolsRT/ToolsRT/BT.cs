using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Foundation;

namespace Tools {
	public sealed class BT {
		public static IAsyncOperation<DeviceInformationCollection> getDeviceInfo(string guid) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					return await getDeviceInfo(new Guid(guid));
				});
			});

		}
		[Windows.Foundation.Metadata.DefaultOverload()]
		public static IAsyncOperation<DeviceInformationCollection> getDeviceInfo(Guid guid) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					var dev = RfcommDeviceService.GetDeviceSelector(RfcommServiceId.FromUuid(guid));
					return await DeviceInformation.FindAllAsync(dev);
				});
			});

		}

	}
}
