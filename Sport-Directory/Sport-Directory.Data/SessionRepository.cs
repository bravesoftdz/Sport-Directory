using System;
using System.Linq;

namespace Sport_Directory.Data
{
    public class SessionRepository
    {
        private readonly DirectoryEntities _context;

        public SessionRepository(DirectoryEntities context)
        {
            _context = context;
        }

        public Guid RegisterSession(Guid userUid)
        {
            if (_context.Session.Any(s => s.UserUID == userUid))
            {
                throw new Exception("There is already a Session Registred for the User: " + userUid);
            }

            Session newSession = new Session
            {
                UID = Guid.NewGuid(),
                SysInsertTime = DateTime.Now,
                SysInsertAccount = Guid.Empty,
                UserUID =userUid,
                AllocationDate = DateTime.Now,
                IntendedExpirationDate = DateTime.Now.AddDays(1),
            };

            _context.Session.Add(newSession);
            _context.SaveChanges();

            return newSession.UID;
        }

        public void RemoveSession(Guid sessionUid)
        {
            Session session = _context.Session.FirstOrDefault(s => s.UID == sessionUid);

            if (session == null)
            {
                throw new Exception("The session: " + sessionUid + " does not exists");
            }

            _context.Session.Remove(session);
            _context.SaveChanges();
        }

        public void CleanSessions()
        {
            _context.Session.RemoveRange(_context.Session);
            _context.SaveChanges();
        }

        public void CleanExpiredSessions()
        {
            _context.Session.RemoveRange(_context.Session.Where(s => s.IntendedExpirationDate < DateTime.Now || s.ExpiratedDate != null));
            _context.SaveChanges();
        }
    }
}
