using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class HistoryDocuments
    {
        [ScaffoldColumn(false)]
        public int ClientId { get; set; }

        [ScaffoldColumn(false)]
        public int DocumentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int HistoryId { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Documents Document { get; set; }
    }
}
