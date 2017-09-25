using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_Directory.DomainContracts.Authentication
{
    public class LogoutQuery
    {
        public Guid SessionUID { get; set; }
    }
}
