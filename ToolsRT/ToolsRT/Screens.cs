using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;

namespace Tools {
	/// <summary>
	/// 画面表示に関するメソッドです。
	/// </summary>
	public sealed class Screens {

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		public static void Message(string content) {
			Message(content,"");
		}

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		/// <param name="title">(<see cref="string"/>)表示したいタイトル</param>
		public static async void Message(string content,string title) {
			await new MessageDialog(content,title).ShowAsync();
		}

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		/// <param name="uics">(<see cref="IList<UICommand>"/>)追加したいコマンド</param>
		/// <returns>(<see cref="int"/>)ユーザーが選択したボタンのコマンドインデックス</returns>
		public static IAsyncOperation<int> MessageAsync(string content,IList<UICommand> uics) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					return await MessageAsync(content,"",uics,0);
				});
			});
		}

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		/// <param name="uics">(<see cref="IList<UICommand>"/>)追加したいコマンド</param>
		/// <param name="cmdindex">(<see cref="uint"/>)デフォルトのコマンドインデックス</param>
		/// <returns>(<see cref="int"/>)ユーザーが選択したボタンのコマンドインデックス</returns>
		public static IAsyncOperation<int> MessageAsync(string content,IList<UICommand> uics,uint cmdindex) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					return await MessageAsync(content,"",uics,cmdindex);
				});
			});
		}

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		/// <param name="title">(<see cref="string"/>)表示したいタイトル</param>
		/// <param name="commands">(<see cref="string"/>)ボタンのテキスト</param>
		/// <returns>(<see cref="int"/>)選択されたボタン(左から0,1,2...)</returns>
		[Windows.Foundation.Metadata.DefaultOverload()]
		public static IAsyncOperation<int> MessageAsync(string content,string title,params string[] commands) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					MessageDialog md = new MessageDialog(content,title);
					int i = 0;
					List<UICommand> uics = new List<UICommand>();
					foreach(var item in commands) {
						uics.Add(new UICommand(item));
					}
					foreach(var item in uics) {
						item.Id = i++;
						md.Commands.Add(item);
					}
					md.DefaultCommandIndex = 0;
					var result = await md.ShowAsync();
					return (int)result.Id;
				});
			});
		}

		/// <summary>
		/// 画面の上にメッセージを表示します。
		/// </summary>
		/// <param name="content">(<see cref="string"/>)表示したいテキスト</param>
		/// <param name="title">(<see cref="string"/>)表示したいタイトル</param>
		/// <param name="uics">(<see cref="IList<UICommand>"/>)追加したいコマンド</param>
		/// <param name="cmdindex">(<see cref="uint"/>)デフォルトのコマンドインデックス</param>
		/// <returns>(<see cref="int"/>)ユーザーが選択したボタンのコマンドインデックス</returns>
		public static IAsyncOperation<int> MessageAsync(string content,string title,IList<UICommand> uics,uint cmdindex) {
			return AsyncInfo.Run((token) => {
				return Task.Run(async () => {
					MessageDialog md = new MessageDialog(content);
					foreach(var item in uics) {
						md.Commands.Add(item);
					}
					md.DefaultCommandIndex = cmdindex;
					var result = await md.ShowAsync();
					return (int)result.Id;
				});
			});
		}

#if WINDOWS_UWP
		/// <summary>
		/// UWPのタイトルバーを変更します
		/// </summary>
		/// <param name="title">(<see cref="string"/>)タイトルバーの文字</param>
		public static void TitleBarChange(string title) {
			if(title != "") {
				ApplicationView.GetForCurrentView().Title = title;

			}
		}
		/// <summary>
		/// UWPのタイトルバーを変更します
		/// </summary>
		/// <param name="backColor">(<see cref="Color"/>)ウィンドウがアクティブの時の背景色</param>
		/// <param name="foreColor">(<see cref="Color"/>)ウィンドウがアクティブの時の文字色</param>
		/// <param name="title">(<see cref="string"/>)タイトルバーの文字</param>
		public static void TitleBarChange(Color backColor,Color foreColor,params string[] title) {
			var titlebar = ApplicationView.GetForCurrentView().TitleBar;
			titlebar.BackgroundColor = titlebar.InactiveForegroundColor
				= titlebar.ButtonInactiveForegroundColor = titlebar.ButtonBackgroundColor = backColor;
			titlebar.ForegroundColor = titlebar.InactiveBackgroundColor
				= titlebar.ButtonInactiveBackgroundColor = titlebar.ButtonForegroundColor = foreColor;
			TitleBarChange(title[0]);
		}
		/// <summary>
		/// UWPのタイトルバーを変更します
		/// </summary>
		/// <param name="backColor">(<see cref="Color"/>)ウィンドウがアクティブの時の背景色</param>
		/// <param name="foreColor">(<see cref="Color"/>)ウィンドウがアクティブの時の文字色</param>
		/// <param name="back_backColor">(<see cref="Color"/>)ウィンドウが非アクティブの時の背景色</param>
		/// <param name="back_foreColor">(<see cref="Color"/>)ウィンドウが非アクティブの時の文字色</param>
		/// <param name="title">(<see cref="string"/>)タイトルバーの文字</param>
		public static void TitleBarChange(Color backColor,Color foreColor,Color back_backColor,Color back_foreColor,params string[] title) {
			var titlebar = ApplicationView.GetForCurrentView().TitleBar;
			titlebar.BackgroundColor = titlebar.ButtonBackgroundColor = backColor;
			titlebar.ForegroundColor = titlebar.ButtonForegroundColor = foreColor;
			titlebar.InactiveForegroundColor = titlebar.ButtonInactiveForegroundColor = back_foreColor;
			titlebar.InactiveBackgroundColor = titlebar.ButtonInactiveBackgroundColor = back_backColor;
			TitleBarChange(title[0]);
		}
	}
#endif
}
