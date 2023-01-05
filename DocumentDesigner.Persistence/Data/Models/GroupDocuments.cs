using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class GroupDocuments
    {
        public GroupDocuments()
        {
            Documents = new HashSet<Documents>();
        }

        public int GroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
    }
}
