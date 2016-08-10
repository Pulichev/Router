using System.Windows;
using Router.View;

namespace Router
{
	public partial class App : Application
	{
		public App()
		{
			new MainWindow().Show();
		}
	}
}
