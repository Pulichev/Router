using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class Super
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Location { get; set; }
		[DataMember]
		public string TerritoryType { get; set; }
		[DataMember]
		public string Company { get; set; }
		[DataMember]
		public string Head { get; set; }
		[DataMember]
		public string Phone { get; set; }
		[DataMember]
		public string EMail { get; set; }
		[DataMember]
		public string State { get; set; }

		//Ключи
		[DataMember]
		public int PlaceId { get; set; }
	}
}
