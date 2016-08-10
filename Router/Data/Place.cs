using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class Place
	{
		[DataMember]
		public int SuperPlacesId { get; set; }
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public int Type { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Region { get; set; }

		public string FullPlaceName
		{
			get
			{
				if (Region == "")
					return Name;
				return Name + " (" + Region + ")";
			}
			set { FullPlaceName = value; }
		}
	}
}
