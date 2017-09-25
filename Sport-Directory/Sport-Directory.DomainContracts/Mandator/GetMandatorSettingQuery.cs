using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_Directory.DomainContracts.Mandator
{
    public class GetMandatorSettingQuery
    {
        public Guid MandatorUID { get; set; }

        public string Key { get; set; }
    }
}
