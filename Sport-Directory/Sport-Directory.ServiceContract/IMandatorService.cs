using System;
using System.Collections.Generic;
using Sport_Directory.Data;

namespace Sport_Directory.ServiceContract
{
    public interface IMandatorService
    {
        Guid GetMandatorUid(Guid sessionid);

        List<MandatorSetting> GetMandatorSettings(Guid mandatorUid);

        MandatorSetting GetMandatorSetting(Guid mandatorUid, string key);
    }
}
