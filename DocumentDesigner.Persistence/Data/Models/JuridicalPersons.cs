using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class JuridicalPersons
    {
        public JuridicalPersons()
        {
            JuridicalPersonIsClient = new HashSet<JuridicalPersonIsClient>();
        }

        public int JuridicalPersonId { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<JuridicalPersonIsClient> JuridicalPersonIsClient { get; set; }
    }
}
