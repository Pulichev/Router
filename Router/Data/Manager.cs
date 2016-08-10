using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class Manager
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string FIO { get; set; }
		[DataMember]
		public string Telephone { get; set; }
		[DataMember]
		public string Mail { get; set; }
		[DataMember]
		public string Commentary { get; set; }

		[DataMember]
		public int SuperId { get; set; }
	}
}
