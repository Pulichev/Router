using Data;

namespace Router.Model
{
	public abstract class SuperDetailsPlaceModel : SuperDetailsCheckedModel<Place>
	{
		protected SuperDetailsPlaceModel(bool IsEnabled, SuperDetailsModel parent, Place item, bool chk)
			: base(IsEnabled, parent, item, chk)
		{
		}

		public int Id
		{
			get
			{
				return Element.Id;
			}
			set
			{
				Element.Id = value;
				OnPropertyChanged("Id");
			}
		}

		public string FullPlaceName
		{
			get
			{
				return Element.FullPlaceName;
			}
			set
			{
				Element.FullPlaceName = value;
				OnPropertyChanged("FullPlaceName");
			}
		}
	}

	public class SuperDetailsPlaceLeaveModel : SuperDetailsPlaceModel
	{

		public SuperDetailsPlaceLeaveModel(bool IsEnabled, SuperDetailsModel parent, Place item, bool chk)
			: base(IsEnabled, parent, item, chk)
		{
		}

		protected override void Add()
		{
			_parent.AddLeave(Element);
		}

		protected override void Remove()
		{
			_parent.RemoveLeave(Element);
		}
	}

	public class SuperDetailsPlaceBrigadeModel : SuperDetailsPlaceModel
	{

		public SuperDetailsPlaceBrigadeModel(bool IsEnabled, SuperDetailsModel parent, Place item, bool chk)
			: base(IsEnabled, parent, item, chk)
		{
		}

		protected override void Add()
		{
			_parent.AddBrigade(Element);
		}

		protected override void Remove()
		{
			_parent.RemoveBrigade(Element);
		}
	}
}