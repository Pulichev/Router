using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class Works
	{
		[DataMember]
		public int WorkId { get; set; }
		[DataMember]
		public int WorkTypeId { get; set; }
	}
}
