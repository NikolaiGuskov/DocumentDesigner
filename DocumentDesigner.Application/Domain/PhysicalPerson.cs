using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class PhysicalPerson
	{
        public int PhysicalPersonId { get; set; }
        public string Name { get; set; }
        public string Syrname { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
