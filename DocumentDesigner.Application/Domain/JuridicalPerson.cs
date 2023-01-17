using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class JuridicalPerson
	{
        public JuridicalPerson()
        {
            JuridicalPersonIsClient = new HashSet<JuridicalPersonlsClient>();
        }

        public int JuridicalPersonId { get; set; }

        public string Name { get; set; }

        public string Inn { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<JuridicalPersonlsClient> JuridicalPersonIsClient { get; set; }
    }
}
