using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
	[DataContract]
	public class SuperDetails
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string NameFact { get; set; }
		[DataMember]
		public string NameLaw { get; set; }
		[DataMember]
		public string HeadName { get; set; }
		[DataMember]
		public string HeadComment { get; set; }
		[DataMember]
		public string HeadPhoneWork { get; set; }
		[DataMember]
		public string HeadPhoneHome { get; set; }
		[DataMember]
		public string HeadPhoneMobile { get; set; }
		[DataMember]
		public string Fax { get; set; }
		[DataMember]
		public string Http { get; set; }
		[DataMember]
		public string HeadEmail { get; set; }
		[DataMember]
		public string FieldName { get; set; }
		[DataMember]
		public string FieldComment { get; set; }
		[DataMember]
		public string FieldPhoneWork { get; set; }
		[DataMember]
		public string FieldPhoneHome { get; set; }
		[DataMember]
		public string FieldPhoneMobile { get; set; }
		[DataMember]
		public string FieldEmail { get; set; }
		[DataMember]
		public int InterCount { get; set; }
		[DataMember]
		public string AddressFact { get; set; }
		[DataMember]
		public string AddressLaw { get; set; }
		[DataMember]
		public int ComputerCount { get; set; }
		[DataMember]
		public int ManagerCount { get; set; }
		[DataMember]
		public string INN { get; set; }
		[DataMember]
		public string KPP { get; set; }
		[DataMember]
		public bool VAT { get; set; }
		[DataMember]
		public string VAT_Argument { get; set; }
		[DataMember]
		public string Recvisits { get; set; }
		[DataMember]
		public string Description { get; set; }
		[DataMember]
		public string FinHead { get; set; }
		[DataMember]
		public string FinPosition { get; set; }
		[DataMember]
		public string WorkOn { get; set; }
		[DataMember]
		public string IndLicense { get; set; }
		[DataMember]
		public string IndTax { get; set; }
		[DataMember]
		public string IndInn { get; set; }
		[DataMember]
		public string IndRegister { get; set; }
		[DataMember]
		public string DescControl { get; set; }
		[DataMember]
		public string Login { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public string Folder { get; set; }
		[DataMember]
		public int Dictaphone { get; set; }
		[DataMember]
		public int Notebook { get; set; }
		[DataMember]
		public int Computer { get; set; }
		[DataMember]
		public int Pda { get; set; }

		//Ключи
		[DataMember]
		public Place PlaceId { get; set; }
		[DataMember]
		public int StateId { get; set; }
		[DataMember]
		public List<Works> Works = new List<Works>();
		[DataMember]
		public List<Place> Brigades = new List<Place>();
		[DataMember]
		public List<Place> Leave = new List<Place>();
		[DataMember]
		public List<Agreement> Agreements = new List<Agreement>();
	}
}
