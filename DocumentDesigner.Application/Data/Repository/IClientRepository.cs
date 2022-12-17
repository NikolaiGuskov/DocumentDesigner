using DocumentDesigner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Data
{
	public interface IClientRepository
	{
		public Client GetClientBy();
	}
}
