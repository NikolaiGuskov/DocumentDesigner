using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class Clients
    {
        public Clients()
        {
            HistoryDocuments = new HashSet<HistoryDocuments>();
            JuridicalPersonIsClient = new HashSet<JuridicalPersonIsClient>();
            PhysicalPersons = new HashSet<PhysicalPersons>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Syrname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<HistoryDocuments> HistoryDocuments { get; set; }
        public virtual ICollection<JuridicalPersonIsClient> JuridicalPersonIsClient { get; set; }
        public virtual ICollection<PhysicalPersons> PhysicalPersons { get; set; }
    }
}
