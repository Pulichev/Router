using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class Agreement
	{
		[DataMember]
		public int AgreeId { get; set; }
		[DataMember]
		public int AgreeTypeId { get; set; }
		[DataMember]
		public string AgreeName { get; set; }
	}
}
