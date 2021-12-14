using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.Sample.Pages.Views.Popups;
using Xamarin.CommunityToolkit.Sample.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Sample.Pages.TestCases.Popups
{
	public partial class GH_BUG_1764
	{
		public GH_BUG_1764() => InitializeComponent();

		private void ButtonB_Clicked(object sender, EventArgs e)
		{
			var popup = new PopupThatDisplayingChild();
			Navigation.ShowPopup(popup);
		}

		public class PopupThatDisplayingChild : Popup
		{
			INavigation Navigation => Application.Current.MainPage.Navigation;
			public PopupThatDisplayingChild()
			{

				Size = new Size(200, 200);

				var sl = new StackLayout();


				var btn = new Button
				{
					Text = "display child popup"
				};
				btn.Clicked += (sender, args) =>
				{
					var popupB = new ButtonPopup();
					Navigation.ShowPopup(popupB);
				};

				sl.Children.Add(btn);

				Content = sl;
			}
		}
	}


	public class GH_BUG_1764_ViewModel : BaseViewModel
	{
		public GH_BUG_1764_ViewModel()
		{

		}

		INavigation Navigation => Application.Current.MainPage.Navigation;
	}
}