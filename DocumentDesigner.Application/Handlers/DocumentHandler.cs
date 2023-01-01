﻿using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.Application.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Handlers
{
	public class DocumentHandler : IDocumentHandler
	{
		public readonly ContextData _contextData;

		public DocumentHandler(ContextData contextData)
		{
			_contextData = contextData;
		}

		public async Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments()
		{
			return await _contextData.Documents.GetAllGroupDocumentWithDocuments();
		}
	}
}