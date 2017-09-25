using System;
using System.Collections.Generic;
using System.Linq;

namespace Sport_Directory.Data
{
    public class MandatorRepository
    {
        private readonly DirectoryEntities _context;

        public MandatorRepository(DirectoryEntities context)
        {
            _context = context;
        }

        public Guid GetMandatorUid(Guid sessionUid)
        {
            var session = _context.Session.FirstOrDefault(s => s.UID == sessionUid);

            if (session == null)
            {
                throw new Exception("The Session: " + sessionUid + " does not exists");
            }

            return session.User.MandatorUID;
        }

        public IEnumerable<MandatorSetting> GetMandatorSetting(Guid mandatorUid, string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                return _context.MandatorSetting.Where(ms => ms.MandatorUID == mandatorUid);
            }

            return _context.MandatorSetting.Where(ms => ms.MandatorUID == mandatorUid && ms.Key == key);
        }
    }
}
