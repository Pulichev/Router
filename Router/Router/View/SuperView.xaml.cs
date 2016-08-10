using System.Windows;
using Core;
using Router.Model;
using Router.ViewModel;

namespace Router.View
{
	public partial class SuperView : Window, IEntityDialog<SuperDetailsModel>
	{
		public SuperView()
        {
            ViewModel = new SuperDetailsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        public void SetEntity(SuperDetailsModel entity)
        {
            ViewModel.SetEntity(entity);
        }

        public SuperDetailsModel GetEntity()
        {
            return ViewModel.Entity;
        }

        public SuperDetailsViewModel ViewModel { get; private set; }

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
