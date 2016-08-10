using System.Collections.Generic;
using System.Linq;
using Data;
using Core;

namespace FakeRepository
{
	public class Repository : IRepository
	{
		private List<SuperDetails> items = new List<SuperDetails>();
		private List<Manager> items1 = new List<Manager>();
		private List<Place> items2 = new List<Place>();
		private List<WorkType> items3 = new List<WorkType>();
		private List<State> items4 = new List<State>();
		private List<Super> items5 = new List<Super>();
		private List<Manager> items6 = new List<Manager>();
		private List<Agreement> items7 = new List<Agreement>();
		
		public Repository()
		{
			//CityAreas
			items2.Add(new Place()
			{
				Id = 1,
				Type = 1,
				Name = "Москва",
				Region = "Москва"
			});
			items2.Add(new Place()
			{
				Id = 2,
				Type = 1,
				Name = "АБАЙ",
				Region = "Казахстан"
			});
			items2.Add(new Place()
			{
				Id = 3,
				Type = 1,
				Name = "Акколь",
				Region = "Казахстан"
			});
			items2.Add(new Place()
			{
				Id = 4,
				Type = 2,
				Name = "Мегель",
				Region = "Иркутская область"
			});

			items.Add(new SuperDetails
			{
				Id = 1,
				NameFact = "Центр Социальных Технологий \"Оптима\"",
				NameLaw = "ЗАО Центр Социальных Технологий \"Оптима\"",
				HeadName = "Маликова Наталья Николаевна",
				HeadComment = "",
				HeadPhoneWork = "(343) 388 15 00, 388 15 01",
				HeadPhoneHome = "",
				HeadPhoneMobile = "8-912-28-64-302",
				Fax = "",
				Http = "",
				HeadEmail = "Natalya_Malikova@optima-ekb.ru; optima@optima-ekb.ru",
				FieldName = "Абрамова Софья Борисовна",
				FieldComment = "Феофанова Ирина, Власова Ольга, Сачкова Валентина Геннадьевна Valentina_Sachkova@optima-ekb.ru",
				FieldPhoneWork = "(343) 355-46-67",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "optima@optima-ekb.ru",
				InterCount = 108,
				AddressFact = "",
				AddressLaw = "620077, Екатеринбург, ул. Октябрьской революции, д.25",
				ComputerCount = 8,
				ManagerCount = 4,
				INN = "6658092499",
				KPP = "665801001",
				VAT = true,
				VAT_Argument = "",
				Recvisits = "р/с 40702810900001001775 в ОАО Уралпромстройбанк” к/с 30101810200000000806  БИК 046577806",
				Description = "167000, г. Сыктывкар, ул. Кирова, 20/18, кв.53 200-865 Конюхов Алексей Кимович Нет CATI Старый optima@optima-ekb.ru; optima@novator.ru   (343) 355-42-22",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[0],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 1, WorkTypeId = 2 }, new Works { WorkId = 2, WorkTypeId = 2 } },
				Brigades = new List<Place> { items2[0], items2[1] },
				Leave = new List<Place> { items2[0], items2[1] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 1, AgreeTypeId = 1 }, new Agreement { AgreeId = 2, AgreeTypeId = 2 } }
			});
			items.Add(new SuperDetails {
				Id = 2,
				NameFact = "Маркетинговые и политические исследования",
				NameLaw = "ООО \"Маркетинговые и политические исследования\"",
				HeadName = "Судомойкин Александр Абросимович",
				HeadComment = "",
				HeadPhoneWork = "(3952) 20-48-44, 25-89-03",
				HeadPhoneHome = "(3952) 25-23-87",
				HeadPhoneMobile = "(3952) 656-251, 8-902-515-62-51",
				Fax = "(3952) 204-844",
				Http = "",
				HeadEmail = "alex_su2003@mail.ru",
				FieldName = "",
				FieldComment = "",
				FieldPhoneWork = "",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "",
				InterCount = 40,
				AddressFact = "664007, Иркутск, ул. С. Перовской, 31 оф. 405",
				AddressLaw = "664047, Иркутск, 1-я Советская 96 – 485",
				ComputerCount = 3,
				ManagerCount = 3,
				INN = "ИНН 3811076535",
				KPP = "КПП 381101001",
				VAT = false,
				VAT_Argument = "согласно упрощенной системе налогообожения",
				Recvisits =
					"р/с 40702810518350105333, Байкальский банк СБ РФ г.Иркутск ОСБ №8586 БИК 042520607  ИНН банка  7707083893 к/с 30101810900000000607",
				Description =
					"БЫЛО - ИНТЕРВЬЮЕРОВ: Иркутск-40, Ангарск-20, Усолье-Сибирское 15, Шелехов-5, Усть-Илимск-15, Братск-20 Черемхово, Тулун - слабые, не брать Телефонник делают по старинке (с листочков)",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[0],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 3, WorkTypeId = 3 }, new Works { WorkId = 4, WorkTypeId = 3 } },
				Brigades = new List<Place> { items2[0], items2[3] },
				Leave = new List<Place> { items2[2], items2[1] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 3, AgreeTypeId = 1 }, new Agreement { AgreeId = 4, AgreeTypeId = 2 } }
			});
			items.Add(new SuperDetails
			{
				Id = 3,
				NameFact = "Кемеровский региональный общественный фонд \"Общественное мнение-Кузбасс\"",
				NameLaw = "Кемеровский региональный общественный фонд \"Общественное мнение-Кузбасс\"",
				HeadName = "Селиванов Олег Юрьевич",
				HeadComment = "",
				HeadPhoneWork = "(3842) 36-38-32",
				HeadPhoneHome = "",
				HeadPhoneMobile = "8-903-907-77-81",
				Fax = "",
				Http = "",
				HeadEmail = "kemotd@yandex.ru",
				FieldName = "",
				FieldComment = "Поличук Елена Валерьевна, Овчинникова Татьяна Владимировна, Степанова Гульнара Гусмановна, Поздерина Светлана Вячеславовна",
				FieldPhoneWork = "(3842) 36-88-56",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "kemotd@kemnet.ru",
				InterCount = 20,
				AddressFact = "",
				AddressLaw = "650099,  г.Кемерово, ул.Ноградская 3",
				ComputerCount = 4,
				ManagerCount = 3,
				INN = "4207057106",
				KPP = "420501001",
				VAT = false,
				VAT_Argument = "на основании Решения ИМНС России по г. Кемерово от",
				Recvisits = "Р/ сч.№ 40703810826020101051  В Сибирском банке Сбербанка  РФ, г.Новосибирск   К/сч. № 30101810500000000641 счет для межфилиальных платежей Сбербанка 3030181034400060260 БИК 045004641",
				Description = "В Кемерово не менее 20 интервьюеров, в остальных городах, где есть бригадиры - в каждом не менее 10. новокузнецк - трудный город Старый адрес: kemotd@kemnet.ru старый 36-88-56",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[1],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 5, WorkTypeId = 1 }, new Works { WorkId = 6, WorkTypeId = 1 } },
				Brigades = new List<Place> { items2[2], items2[0] },
				Leave = new List<Place> { items2[1] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 5, AgreeTypeId = 1 } }
			});
			items.Add(new SuperDetails {
				Id = 4,
				NameFact = "Исследовательская компания \"Делфи\"",
				NameLaw = "",
				HeadName = "Климанова Евгения Геннадиевна",
				HeadComment =
					"ТЮМЕНЬ-Ковешников Геннадий Григорьевич (3452)49-08-56, 8-951-416-06-65 Пащина Елена Викторовна-финанс.директор  buhgalt01@delfi2000.ru (3812) 470-320",
				HeadPhoneWork = " (3812) 394-915, (3812) 394-916.",
				HeadPhoneHome = "(3812) 45-18-59",
				HeadPhoneMobile = "8-913-651-61-56, 8 (3812) 51-61-56",
				Fax = "",
				Http = "",
				HeadEmail = "jane@delfi2000.ru; klimanova@delfi2000.ru; delfi_omsk@mail.ru; research@delfi2000.ru",
				FieldName = "",
				FieldComment =
					"Поличук Елена Валерьевна, Овчинникова Татьяна Владимировна, Степанова Гульнара Гусмановна, Поздерина Светлана Вячеславовна",
				FieldPhoneWork = "(3842) 36-88-56",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "kemotd@kemnet.ru",
				InterCount = 20,
				AddressFact = "",
				AddressLaw = "650099,  г.Кемерово, ул.Ноградская 3",
				ComputerCount = 4,
				ManagerCount = 3,
				INN = "4207057106",
				KPP = "420501001",
				VAT = false,
				VAT_Argument = "на основании Решения ИМНС России по г. Кемерово от",
				Recvisits =
					"Р/ сч.№ 40703810826020101051  В Сибирском банке Сбербанка  РФ, г.Новосибирск   К/сч. № 30101810500000000641 счет для межфилиальных платежей Сбербанка 3030181034400060260 БИК 045004641",
				Description =
					"В Кемерово не менее 20 интервьюеров, в остальных городах, где есть бригадиры - в каждом не менее 10. новокузнецк - трудный город Старый адрес: kemotd@kemnet.ru старый 36-88-56",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[1],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 7, WorkTypeId = 1 }, new Works { WorkId = 8, WorkTypeId = 2 } },
				Brigades = new List<Place> { items2[2], items2[1] },
				Leave = new List<Place> { items2[0], items2[1] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 6, AgreeTypeId = 1 }, new Agreement { AgreeId = 7, AgreeTypeId = 2 } }
			});
			items.Add(new SuperDetails
			{
				Id = 5,
				NameFact = "Дальневосточный маркетинговый центр \"Мониторинг\"",
				NameLaw = "",
				HeadName = "Климанова Евгения Геннадиевна",
				HeadComment = "ТЮМЕНЬ-Ковешников Геннадий Григорьевич (3452)49-08-56, 8-951-416-06-65 Пащина Елена Викторовна-финанс.директор  buhgalt01@delfi2000.ru (3812) 470-320",
				HeadPhoneWork = " (3812) 394-915, (3812) 394-916.",
				HeadPhoneHome = "(3812) 45-18-59",
				HeadPhoneMobile = "8-913-651-61-56, 8 (3812) 51-61-56",
				Fax = "",
				Http = "",
				HeadEmail = "jane@delfi2000.ru; klimanova@delfi2000.ru; delfi_omsk@mail.ru; research@delfi2000.ru",
				FieldName = "",
				FieldComment = "Поличук Елена Валерьевна, Овчинникова Татьяна Владимировна, Степанова Гульнара Гусмановна, Поздерина Светлана Вячеславовна",
				FieldPhoneWork = "(3842) 36-88-56",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "kemotd@kemnet.ru",
				InterCount = 20,
				AddressFact = "",
				AddressLaw = "650099,  г.Кемерово, ул.Ноградская 3",
				ComputerCount = 4,
				ManagerCount = 3,
				INN = "4207057106",
				KPP = "420501001",
				VAT = false,
				VAT_Argument = "на основании Решения ИМНС России по г. Кемерово от",
				Recvisits = "Р/ сч.№ 40703810826020101051  В Сибирском банке Сбербанка  РФ, г.Новосибирск   К/сч. № 30101810500000000641 счет для межфилиальных платежей Сбербанка 3030181034400060260 БИК 045004641",
				Description = "В Кемерово не менее 20 интервьюеров, в остальных городах, где есть бригадиры - в каждом не менее 10. новокузнецк - трудный город Старый адрес: kemotd@kemnet.ru старый 36-88-56",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[1],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 9, WorkTypeId = 3 }, new Works { WorkId = 10, WorkTypeId = 4 } },
				Brigades = new List<Place> { items2[1], items2[2] },
				Leave = new List<Place> { items2[3], items2[2] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 8, AgreeTypeId = 1 }, new Agreement { AgreeId = 9, AgreeTypeId = 2 } }
			});
			items.Add(new SuperDetails
			{
				Id = 6,
				NameFact = "Дальневосточная Исследовательская Компания",
				NameLaw = "",
				HeadName = "Климанова Евгения Геннадиевна",
				HeadComment = "ТЮМЕНЬ-Ковешников Геннадий Григорьевич (3452)49-08-56, 8-951-416-06-65 Пащина Елена Викторовна-финанс.директор  buhgalt01@delfi2000.ru (3812) 470-320",
				HeadPhoneWork = " (3812) 394-915, (3812) 394-916.",
				HeadPhoneHome = "(3812) 45-18-59",
				HeadPhoneMobile = "8-913-651-61-56, 8 (3812) 51-61-56",
				Fax = "",
				Http = "",
				HeadEmail = "jane@delfi2000.ru; klimanova@delfi2000.ru; delfi_omsk@mail.ru; research@delfi2000.ru",
				FieldName = "",
				FieldComment = "Поличук Елена Валерьевна, Овчинникова Татьяна Владимировна, Степанова Гульнара Гусмановна, Поздерина Светлана Вячеславовна",
				FieldPhoneWork = "(3842) 36-88-56",
				FieldPhoneHome = "",
				FieldPhoneMobile = "",
				FieldEmail = "kemotd@kemnet.ru",
				InterCount = 20,
				AddressFact = "",
				AddressLaw = "650099,  г.Кемерово, ул.Ноградская 3",
				ComputerCount = 4,
				ManagerCount = 3,
				INN = "4207057106",
				KPP = "420501001",
				VAT = false,
				VAT_Argument = "на основании Решения ИМНС России по г. Кемерово от",
				Recvisits = "Р/ сч.№ 40703810826020101051  В Сибирском банке Сбербанка  РФ, г.Новосибирск   К/сч. № 30101810500000000641 счет для межфилиальных платежей Сбербанка 3030181034400060260 БИК 045004641",
				Description = "В Кемерово не менее 20 интервьюеров, в остальных городах, где есть бригадиры - в каждом не менее 10. новокузнецк - трудный город Старый адрес: kemotd@kemnet.ru старый 36-88-56",
				FinHead = "",
				FinPosition = "",
				WorkOn = "",
				IndLicense = "",
				IndTax = "",
				IndInn = "",
				IndRegister = "",
				DescControl = "",
				Login = "mic_4",
				Password = "5Z2ApNFc",
				Folder = "54G6jZL3ZBNB5fpSimoahrFcoo7rFA",
				Dictaphone = 0,
				Notebook = 0,
				Computer = 0,
				Pda = 0,
				PlaceId = items2[0],
				StateId = 2,
				Works = new List<Works> { new Works { WorkId = 11, WorkTypeId = 4 }, new Works { WorkId = 12, WorkTypeId = 3 } },
				Brigades = new List<Place> { items2[3], items2[0] },
				Leave = new List<Place> { items2[3] },
				Agreements = new List<Agreement> { new Agreement { AgreeId = 10, AgreeTypeId = 2 }, new Agreement { AgreeId = 11, AgreeTypeId = 2 } }
			});

			//Manager
			items1.Add(new Manager()
			{
				Id = 1, 
				FIO = "Кузнецов Андрей Петрович",
				Telephone = "89001231233",
				Mail = "afsddfsaf@gmail.com",
				Commentary = "Нет комментария",
				SuperId = 2
			});
			items1.Add(new Manager()
			{
				Id = 2,
				FIO = "Артемкин Геннадий Малахович",
				Telephone = "89033334141",
				Mail = "sadfasffsaf@gmail.com",
				Commentary = "Нет комментария",
				SuperId = 1
			});
			items1.Add(new Manager()
			{
				Id = 3,
				FIO = "Петров Петр Петрович",
				Telephone = "89012345678",
				Mail = "asd232323sdf@gmail.com",
				Commentary = "Есть комментарий",
				SuperId = 5
			});
			items1.Add(new Manager()
			{
				Id = 4,
				FIO = "Митин Иван Дмитриевич",
				Telephone = "89012444678",
				Mail = "asdf5454df@gmail.com",
				Commentary = "Есть комментарий",
				SuperId = 6
			});
			items1.Add(new Manager()
			{
				Id = 5,
				FIO = "Смолин Геннадий Петрович",
				Telephone = "89012222678",
				Mail = "as123fsdf@gmail.com",
				Commentary = "Есть комментарий",
				SuperId = 3
			});
			items1.Add(new Manager()
			{
				Id = 6,
				FIO = "Алиев Геннадий Петрович",
				Telephone = "89014622678",
				Mail = "as123f123213sdf@gmail.com",
				Commentary = "Есть комментарий",
				SuperId = 4
			});
			items1.Add(new Manager()
			{
				Id = 7,
				FIO = "Смолин Артем Петрович",
				Telephone = "89012222123",
				Mail = "as123f12323sdf@gmail.com",
				Commentary = "Есть комментарий",
				SuperId = 4
			});

			//WorkTypes
			items3.Add(new WorkType()
			{
				Id = 1,
				Name = "квартирный опрос (маршрут)"
			});

			items3.Add(new WorkType()
			{
				Id = 2,
				Name = "телефонный опроc"
			});
			items3.Add(new WorkType()
			{
				Id = 3,
				Name = "холл-тест"
			});
			items3.Add(new WorkType()
			{
				Id = 4,
				Name = "фокус-группа"
			});
			items3.Add(new WorkType()
			{
				Id = 5,
				Name = "бизнес интервью"
			});

			//States
			items4.Add(new State()
			{
				Id = 1,
				Name = "не работали"
			});
			items4.Add(new State()
			{
				Id = 2,
				Name = "работаем"
			});
			items4.Add(new State()
			{
				Id = 3,
				Name = "работали ранее, опыт положительный"
			});
			items4.Add(new State()
			{
				Id = 4,
				Name = "работали ранее, опыт отрицательный"
			});
			items4.Add(new State()
			{
				Id = 5,
				Name = "не существует"
			});
			
			//Agreements
			items7.Add(new Agreement
			{
				AgreeTypeId = 1,
				AgreeName = "Соглашение фейк 1"
			});
			items7.Add(new Agreement
			{
				AgreeTypeId = 2,
				AgreeName = "Соглашение фейк 2"
			});
			items7.Add(new Agreement
			{
				AgreeTypeId = 3,
				AgreeName = "Соглашение фейк 1"
			});
		}

		public SuperDetails SuperDetailsElement(int superId)
		{
			foreach (var superDetails in items)
				if(superDetails.Id == superId)
					return superDetails;
			return null;
		}

		public IEnumerable<Manager> ManagerList(int superId)
		{
			items6.Clear();
			foreach (var m in items1)
				if (superId == m.SuperId)
					items6.Add(m);
			return items6;
		}

		public IEnumerable<Place> PlaceList()
		{
			return items2;
		}

		public IEnumerable<WorkType> WorkTypeList()
		{
			return items3;
		}

		public IEnumerable<State> StateList()
		{
			return items4;
		}

		public List<Agreement> AgreeTypeList()
		{
			return items7;
		}

		public IEnumerable<Super> SuperList(int place, int placeType, int workType, int state)
		{
			items5.Clear();
			var superAlreadyAdded = 0;
			var fullPlaceName = "";

			foreach (var super in items)
			{
				foreach (var p in items2)
					if (p.Id == super.PlaceId.Id && p.Type == super.PlaceId.Type)
						fullPlaceName = p.FullPlaceName;

				superAlreadyAdded = 0;
				if (super.StateId == state || state == 0)
				{
					foreach (var works in super.Works)
					{
						if (works.WorkTypeId == workType || workType == 0)
						{
							if ((super.PlaceId.Id == place && super.PlaceId.Type == placeType) || place == 0)
							{
								superAlreadyAdded = 1;
								SuperAdd(super, fullPlaceName, "расположен");
							}

							//Для выезжают
							foreach (var L in super.Leave)
								if (superAlreadyAdded == 0)
									if ((L.Id == place && L.Type == placeType) || place == 0)
									{
										SuperAdd(super, fullPlaceName, "выезжают для работы");
										superAlreadyAdded = 1;
									}

							//Для бригад
							foreach (var B in super.Brigades)
								if (superAlreadyAdded == 0)
									if ((B.Id == place && B.Type == placeType) || place == 0)
										SuperAdd(super, fullPlaceName, "постоянные бригады");
							break;
						}
					}
				}
			}
			return items5;
		}

		private void SuperAdd(SuperDetails super, string fullPlaceName, string territoryType)
		{
			items5.Add(new Super()
			{
				Id = super.Id,
				Location = fullPlaceName,
				TerritoryType = territoryType,
				Company = super.NameFact,
				Head = super.HeadName,
				Phone = super.HeadPhoneWork,
				EMail = super.HeadEmail,
				State = items4[super.StateId - 1].Name
			});
		}

		public void ManagerAdd(Manager manager)
		{
			manager.Id = items1.Max(x => x.Id) + 1;
			items1.Add(manager);
		}

		public void SuperDetailsAdd(SuperDetails super)
		{
			super.Id = items.Max(x => x.Id) + 1;
			items.Add(super);
		}

		public void ManagerDelete(int managerId)
		{
			foreach (var manager in items1)
				if (manager.Id == managerId)
				{
					items1.Remove(manager);
					break;
				}
		}

		public void SuperDelete(int superId)
		{
			foreach (var SD in items.ToArray())
				if (SD.Id == superId)
						items.Remove(SD);
		}

		public void ManagerUpdate(Manager manager)
		{
			var index = 0;
			foreach (var m in items1.ToArray())
				if (m.Id == manager.Id)
					index = items1.IndexOf(m);
				items1[index] = manager;
		}

		public void SuperUpdate(SuperDetails super)
		{
			var index = 0;
			foreach (var sd in items.ToArray())
				if (sd.Id == super.Id)
					index = items.IndexOf(sd);
			if (index != 0)
				items[index] = super;
		}
	}
}
 