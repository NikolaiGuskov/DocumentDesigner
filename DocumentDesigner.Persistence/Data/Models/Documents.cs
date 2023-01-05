using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class Documents
    {
        public Documents()
        {
            HistoryDocuments = new HashSet<HistoryDocuments>();
        }

        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string ViewName { get; set; }
        public int GroupId { get; set; }

        public virtual GroupDocuments Group { get; set; }
        public virtual ICollection<HistoryDocuments> HistoryDocuments { get; set; }
    }
}
