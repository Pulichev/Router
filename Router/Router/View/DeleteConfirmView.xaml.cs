using System.Windows;

namespace Router.View
{
	public partial class DeleteConfirmView : Window
	{
		public DeleteConfirmView()
		{
			InitializeComponent();
		}

		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

	}
}
