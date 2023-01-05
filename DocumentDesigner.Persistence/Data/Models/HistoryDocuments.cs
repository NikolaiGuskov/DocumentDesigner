using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class HistoryDocuments
    {
        public int ClientId { get; set; }
        public int DocumentId { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Documents Document { get; set; }
    }
}
