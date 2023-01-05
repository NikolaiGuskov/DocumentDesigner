using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class JuridicalPersonIsClient
    {
        public int JuridicalPersonId { get; set; }
        public int ClientId { get; set; }

        public virtual Clients Client { get; set; }
        public virtual JuridicalPersons JuridicalPerson { get; set; }
    }
}
