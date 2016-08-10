using System.Windows;
using Core;
using Router.Model;
using Router.ViewModel;

namespace Router.View
{
	public partial class ManagerView : Window, IEntityDialog<ManagerModel>
	{
		public ManagerView(ManagerDetailsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }

        public void SetEntity(ManagerModel entity)
        {
            ViewModel.SetEntity(entity);
        }

        public ManagerModel GetEntity()
        {
            return ViewModel.Entity;
        }

        private ManagerDetailsViewModel ViewModel { get; set; }

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
