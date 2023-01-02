using System.Collections.Generic;
using System.Linq;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class GroupDocumentViewModels
	{
		private int _groupByCounter = 2;

		private IReadOnlyCollection<GroupDocumentViewModel> _groupDocuments;

		public GroupDocumentViewModels(IReadOnlyCollection<GroupDocumentViewModel> groupDocuments)
		{
			_groupDocuments = groupDocuments;
		}

		public IReadOnlyCollection<IReadOnlyCollection<GroupDocumentViewModel>> Split()
		{
			return _groupDocuments
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / _groupByCounter)
				.Select(x => x.Select(v => v.Value).ToArray())
				.ToArray();
		}
	}
}
