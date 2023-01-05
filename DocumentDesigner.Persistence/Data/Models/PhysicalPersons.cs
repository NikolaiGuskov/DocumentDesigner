using System;
using System.Collections.Generic;

namespace DocumentDesigner.Persistence.Data.Models
{
    public partial class PhysicalPersons
    {
        public int PhysicalPersonId { get; set; }
        public string Name { get; set; }
        public string Syrname { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int ClientId { get; set; }

        public virtual Clients Client { get; set; }
    }
}
