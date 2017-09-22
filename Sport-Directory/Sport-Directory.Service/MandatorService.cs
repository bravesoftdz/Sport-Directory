using System;
using System.Collections.Generic;
using Sport_Directory.Data;
using Sport_Directory.ServiceContract;

namespace Sport_Directory.Service
{
    public class MandatorService : IMandatorService
    {
        private readonly MandatorRepository _mandatorRepository;

        public MandatorService(MandatorRepository mandatorRepository)
        {
            if (_mandatorRepository != null)
            {
                _mandatorRepository = mandatorRepository;
            }
            else
            {
                _mandatorRepository = new MandatorRepository(new DirectoryEntities());
            }
        }

        public Guid GetMandatorUid(Guid sessionid)
        {
            return _mandatorRepository.GetMandatorUid(sessionid);
        }

        public List<MandatorSetting> GetMandatorSettings(Guid mandatorUid)
        {
            return _mandatorRepository.GetMandatorSettings(mandatorUid);
        }

        public MandatorSetting GetMandatorSetting(Guid mandatorUid, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _mandatorRepository.GetMandatorSetting(mandatorUid, key);
        }
    }
}
