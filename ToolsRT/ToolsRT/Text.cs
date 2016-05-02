using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Storage;

namespace Tools {
	/// <summary>
	/// テキストファイルを扱うメソッドです。
	/// </summary>
	public sealed class Text {

		/// <summary>
		/// テキストファイルを読み込みます。
		/// </summary>
		/// <param name="filename">(<see cref="string"/>)ファイル名</param>
		/// <returns>(<see cref="string"/>)</returns>
		public static IAsyncOperation<string> ReadAsync(string filename) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					string return_str;
					StorageFolder isf = Package.Current.InstalledLocation;
					var sf = await isf.GetFileAsync(filename);
					using(Stream st = (await sf.OpenReadAsync()).AsStream())
					using(TextReader tr = new StreamReader(st)) {
						return_str = await tr.ReadToEndAsync();
					}
					return return_str;
				});
			});

		}

	}
}
