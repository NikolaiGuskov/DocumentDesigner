using System.Collections.Generic;
using System.Linq;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class GroupDocumentViews
	{
		private int _groupByCounter = 2;

		private IReadOnlyCollection<GroupDocumentView> _groupDocuments;

		public GroupDocumentViews(IReadOnlyCollection<GroupDocumentView> groupDocuments)
		{
			_groupDocuments = groupDocuments;
		}

		public IReadOnlyCollection<IReadOnlyCollection<GroupDocumentView>> Split()
		{
			return _groupDocuments
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / _groupByCounter)
				.Select(x => x.Select(v => v.Value).ToArray())
				.ToArray();
		}
	}
}
