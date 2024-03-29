﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class Client
	{
		public int ClientID { get; set; }

		public string Name { get; set; }

		public string Syrname { get; set; }

		public string Patronymic { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public IReadOnlyCollection<HistoryDocument> HistoryDocuments { get; set; }

		public IReadOnlyCollection<JuridicalPersonlsClient> JuridicalPersonIsClient { get; set; }

		public IReadOnlyCollection<PhysicalPerson> PhysicalPersons { get; set; }
	}
}
