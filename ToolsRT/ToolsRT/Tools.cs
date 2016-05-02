//Ver 1.0.0.0
/* 更新履歴
 * V1.0.0.0 ToolsRT作成
*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.System.Profile;

namespace Tools {
	public sealed class DeviceSetting {
		public static bool isMobile { get { return AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile"; } }
	}

	public enum selectTheme {
		Default, Light, Dark
	}

	public enum selectOrientation {
		Landscape, Portrait
	}

	public static class Times {
		public static void Start() {
			Data.SaveTemp("Tools_time_tmp",DateTime.Now.Ticks.ToString());
		}

		public static async void Stop() {
			long time = long.Parse(await Data.LoadTempAsync("Tools_time_tmp"));
			time = DateTime.Now.Ticks - time;
			Debug.WriteLine("");
			Debug.WriteLine(time);
			Debug.WriteLine(new TimeSpan(time));
			Debug.WriteLine("");
		}
	}

}
