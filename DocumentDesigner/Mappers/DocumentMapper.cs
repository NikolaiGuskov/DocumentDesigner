using DocumentDesigner.Application.Domain;
using DocumentDesigner.WebApi.ViewModels;

namespace DocumentDesigner.WebApi.Mappers
{
	public static class DocumentMapper
	{
		public static GroupDocumentViewModel MapInGroupDocumentView(this GroupDocument groupDocument)
		{
			return new GroupDocumentViewModel
			{
				GroupID = groupDocument.GroupID,
				Title = groupDocument.Title,
				Description = groupDocument.Description,
				Documents = groupDocument.Documents
			};
		}
	}
}
