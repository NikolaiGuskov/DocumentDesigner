using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public interface IDocumentDesignerDbContext
	{
		Task<int> SaveChangesAsync();
	}
}
