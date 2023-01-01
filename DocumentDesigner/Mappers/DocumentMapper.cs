using DocumentDesigner.Application.Domain;
using DocumentDesigner.WebApi.ViewModels;

namespace DocumentDesigner.WebApi.Mappers
{
	public static class DocumentMapper
	{
		public static GroupDocumentView MapInGroupDocumentView(this GroupDocument groupDocument)
		{
			return new GroupDocumentView
			{
				GroupID = groupDocument.GroupID,
				Title = groupDocument.Title,
				Description = groupDocument.Description,
				Documents = groupDocument.Documents
			};
		}
	}
}
