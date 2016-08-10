using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class State
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
	}
}
