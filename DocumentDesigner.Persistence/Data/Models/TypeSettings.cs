using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class TypeSettings
    {
        public TypeSettings()
        {
            Settings = new HashSet<Settings>();
        }

        public int TypeSettingId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Settings> Settings { get; set; }
    }
}
