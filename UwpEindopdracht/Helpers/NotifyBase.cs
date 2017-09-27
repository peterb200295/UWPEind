using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace UwpEindopdracht.Helpers
{
	public abstract class NotifyBase : INotifyPropertyChanged
	{
			public event PropertyChangedEventHandler PropertyChanged;

			protected async void OnPropertyChanged([CallerMemberName] string propName = "")
			{
				await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High,
					() =>
					{
						PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
					});
			}
	}
}
