using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class JuridicalPersonlsClient
	{
		public int JuridicalPersonId { get; set; }

		public int ClientId { get; set; }

		public virtual Client Client { get; set; }

		public virtual JuridicalPerson JuridicalPerson { get; set; }
	}
}
