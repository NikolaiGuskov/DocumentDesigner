﻿using DocumentDesigner.Application.Domain;
using DocumentDesigner.Persistence.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentDesigner.Persistence.Mappers
{
	public static class DocumentMapper
	{
		public static Documents MapFromDomainDocument(this Document document)
		{
			return new Documents
			{
				DocumentId = document.DocumentID,
				GroupId = document.Group.GroupID,
				Name = document.Name,
				ViewName = document.ViewName
			};
		}

		public static Document MapInDomainDocument(this Documents document)
		{
			return new Document
			{
				DocumentID = document.DocumentId,
				Group = new GroupDocument { GroupID = document.Group.GroupId },
				Name = document.Name,
				ViewName = document.ViewName
			};
		}

		public static GroupDocument MapInDomainGroupDocument(this GroupDocuments group)
		{
			var documents = group.Documents.Select(d => MapInDomainDocument(d));

			return new GroupDocument
			{
				Description = group.Description,
				GroupID = group.GroupId,
				Title = group.Title,
				Documents = documents.ToArray()
			};
		}

		public static HistoryDocument MapInDomainHistoryDocument(this HistoryDocuments history)
		{
			return new HistoryDocument
			{
				Client = ClientMapper.MapInDomainClient(history.Client),
				Document = MapInDomainDocument(history.Document),
				CreateDate = history.CreateDate.Value,
				HistoryID = history.HistoryId
			};
		}
	}
}
