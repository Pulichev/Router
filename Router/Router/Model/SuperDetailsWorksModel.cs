using System.Linq;
using Data;

namespace Router.Model
{
	public class SuperDetailsWorksModel : SuperDetailsCheckedModel<WorkType>
	{

		public SuperDetailsWorksModel(bool IsEnabled, SuperDetailsModel parent, WorkType item, bool chk)
			: base(IsEnabled ,parent, item, chk)
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

		public string Name
		{
			get
			{
				return Element.Name;
			}
			set
			{
				Element.Name = value;
				OnPropertyChanged("Name");
			}
		} 

		protected override void Add()
		{
			_parent.AddWork(new Works { WorkTypeId = Element.Id});
		}

		protected override void Remove()
		{
			foreach (var work in _parent.Element.Works.ToList())
			{
				if (work.WorkTypeId == Element.Id)
					_parent.RemoveWork(work);
			}
		}
	}
}
