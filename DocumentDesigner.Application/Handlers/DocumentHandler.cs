using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.Application.Handlers.Interfaces;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Handlers
{
	public class DocumentHandler : IDocumentHandler
	{
		private readonly ContextData _contextData;

		public DocumentHandler(ContextData contextData)
		{
			_contextData = contextData;
		}

		public async Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments()
		{
			try
			{
				return await _contextData.Documents.GetAllGroupDocumentWithDocuments();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<Document> GetDocumentByID(int documentID)
		{
			try
			{
				var document = await _contextData.Documents.GetDocumentByID(documentID);

				if (document == null)
					throw new ArgumentNullException(nameof(document));

				return document;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<byte[]> GenerateDocumentInPDF(string html)
		{
			try
			{
				var Renderer = new HtmlToPdf();
				var PDF = await Renderer.RenderHtmlAsPdfAsync(html);

				return PDF.BinaryData;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
