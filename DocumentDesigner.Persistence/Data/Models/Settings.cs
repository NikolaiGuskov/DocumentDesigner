using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class Settings
    {
        public int SettingId { get; set; }
        public int TypeSerringsId { get; set; }
        public string Value { get; set; }

        public virtual TypeSettings TypeSerrings { get; set; }
    }
}
