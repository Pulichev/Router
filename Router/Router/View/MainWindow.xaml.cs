using Router.ViewModel;
using Router.Dialogs;
//using WCFRepository;
using FakeRepository;
using Window = System.Windows.Window;

namespace Router.View
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel(new Repository(), new DialogManager(new DialogFactory())); 
		}
	}
}
