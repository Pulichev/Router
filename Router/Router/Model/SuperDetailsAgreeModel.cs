using Data;

namespace Router.Model
{
	public class SuperDetailsAgreeModel : SuperDetailsCheckedModel<Agreement>
	{

		public SuperDetailsAgreeModel(bool IsEnabled, SuperDetailsModel parent, Agreement item, bool chk)
			: base(IsEnabled, parent, item, chk)
		{
		}

		public int Id
		{
			get
			{
				return Element.AgreeId;
			}
			set
			{
				Element.AgreeId = value;
				OnPropertyChanged("AgreeId");
			}
		}

		public string AgreeName
		{
			get
			{
				return Element.AgreeName;
			}
			set
			{
				Element.AgreeName = value;
				OnPropertyChanged("AgreeName");
			}
		}

		protected override void Add()
		{
			_parent.AddAgree(new Agreement { AgreeTypeId = Element.AgreeTypeId });
		}

		protected override void Remove()
		{
			_parent.RemoveAgree(Element);
		}
	}
}
