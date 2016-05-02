using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;

namespace Tools {
	/// <summary>
	/// データの保存、読み込みをするメソッドです。
	/// </summary>
	public sealed class Data {

		/// <summary>
		/// ローカルデータを保存します。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="value"><see cref="object"/>値</param>
		public static void Save(string key,object value) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
				container.Values[key] = value;
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// ローカルデータを読み込みます。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="val"></param>
		/// <returns><see cref="object"/>読み込みに成功したときに、このメソッドが返される時 object 型で値を格納します。読み込みに失敗したときは null を格納します。</returns>
		public static object Load(string key) {
			object val;
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;

				if(container.Values.ContainsKey(key)) {
					val = container.Values[key];
					return val;
				}
				else {
					val = null;
					return val;
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				val = null;
				return val;
			}
		}

		/// <summary>
		/// ローカルデータを読み込みます。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="val"><see cref="object"/>読み込みに成功したときに、このメソッドが返される時 object 型で値を格納します。読み込みに失敗したときは null を格納します。</param>
		/// <returns><see cref="bool"/>読み込みが成功した場合 true 、失敗した時は false を返します。</returns>
		[Windows.Foundation.Metadata.DefaultOverload()]
		public static bool Load(string key,out object val) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
				if(container.Values.ContainsKey(key)) {
					val = container.Values[key];
					return true;
				}
				else {
					val = null;
					return false;
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				val = null;
				return false;
			}
		}

		/// <summary>
		/// ローカルデータを読み込み出来るかどうかを判定します。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <returns><see cref="bool"/>読み込みが成功した場合 true 、失敗した時は false を返します。</returns>
		public static bool IsLoad(string key) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
				if(container.Values.ContainsKey(key)) {
					return true;
				}
				else {
					return false;
				}
			}
			catch {
				return false;
			}
		}

		/// <summary>
		/// ローカルデータの中を一覧で取得します
		/// </summary>
		/// <returns><see cref="List<string>"/></returns>
		public static IReadOnlyList<string> LoadAllKeys() {
			List<string> keys = new List<string>();
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
				foreach(var item in container.Values) {
					keys.Add(item.Key);
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				return new List<string>();
			}
			return keys;
		}

		/// <summary>
		/// ローカルデータを削除します。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <returns><see cref="bool"/>削除が成功した場合 true 、失敗した時は false を返します。</returns>
		public static bool Delete(string key) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.LocalSettings;
				container.Values.Remove(key);
				return true;
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
			}
			return false;
		}

		/// <summary>
		/// ローミングデータを保存します
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="value"><see cref="string"/>値</param>
		public static void SaveRoaming(string key,object value) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;
				container.Values[key] = value;
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// ローミングデータを読み込みます。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <returns><see cref="object"/>読み込みに成功したときに、このメソッドが返される時 object 型で値を格納します。読み込みに失敗したときは null を格納します。</returns>
		public static object LoadRoaming(string key) {
			object val;
			try {
				ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;
				if(container.Values.ContainsKey(key)) {
					val = container.Values[key];
					return val;
				}
				else {
					val = null;
					return val;
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				val = null;
				return val;
			}
		}

		/// <summary>
		/// ローミングデータを読み込みます。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="val"><see cref="object"/>読み込みに成功したときに、このメソッドが返される時 object 型で値を格納します。読み込みに失敗したときは null を格納します。</param>
		/// <returns><see cref="bool"/>読み込みが成功した場合 true 、失敗した時は false を返します。</returns>
		[Windows.Foundation.Metadata.DefaultOverload()]
		public static bool LoadRoaming(string key,out object val) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;
				if(container.Values.ContainsKey(key)) {
					val = container.Values[key];
					return true;
				}
				else {
					val = null;
					return false;
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				val = null;
				return false;
			}
		}

		/// <summary>
		/// ローミングデータの中を一覧で取得します
		/// </summary>
		/// <returns><see cref="List<string>"/></returns>
		public static IReadOnlyList<string> LoadRoamingAllKeys() {
			List<string> keys = new List<string>();
			try {
				ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;
				foreach(var item in container.Values) {
					keys.Add(item.Key);
				}
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
				return new List<string>();
			}
			return keys;
		}

		/// <summary>
		/// ローミングデータを削除します。
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <returns><see cref="bool"/>削除が成功した場合 true 、失敗した時は false を返します。</returns>
		public static bool DeleteRoaming(string key) {
			try {
				ApplicationDataContainer container = ApplicationData.Current.RoamingSettings;
				container.Values.Remove(key);
				return true;
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
			}
			return false;
		}

		/// <summary>
		/// 一時データを保存します
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <param name="value"><see cref="string"/>値</param>
		public static async void SaveTemp(string key,string value) {
			try {
				StorageFolder folder = ApplicationData.Current.TemporaryFolder;
				StorageFile file = await folder.CreateFileAsync(key,CreationCollisionOption.ReplaceExisting);
				await FileIO.WriteTextAsync(file,value);
			}
			catch(Exception ex) {
				Debug.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 一時データを読み込みます
		/// </summary>
		/// <param name="key"><see cref="string"/>キー</param>
		/// <returns><see cref="string"/>文字列の値。存在しないときは string.Empty です</returns>
		public static IAsyncOperation<string> LoadTempAsync(string key) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					try {
						StorageFolder folder = ApplicationData.Current.TemporaryFolder;
						StorageFile file = await folder.GetFileAsync(key);
						if(file != null) {
							return await FileIO.ReadTextAsync(file);
						}
						else {
							return string.Empty;
						}
					}
					catch(Exception ex) {
						Debug.WriteLine(ex.Message);
						return string.Empty;
					}
				});
			});

		}

		/// <summary>
		/// ローカルデータの中を一覧で取得します
		/// </summary>
		/// <returns><see cref="List<string>"/></returns>
		public static IAsyncOperation<IReadOnlyList<string>> LoadTempAllKeysAsync() {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					List<string> keys = new List<string>();
					try {
						StorageFolder folder = ApplicationData.Current.TemporaryFolder;
						var files = await folder.GetFilesAsync();
						if(files != null) {
							foreach(var item in files) {
								keys.Add(item.Name);
							}
						}
						else {
							keys = new List<string>();
						}
					}
					catch(Exception ex) {
						Debug.WriteLine(ex.Message);
						keys = new List<string>();
					}
					return (IReadOnlyList<string>)keys;
				});
			});

		}

	}
}
