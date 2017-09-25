using System;
using System.Linq;

namespace Sport_Directory.Data
{
    public class AuthenticationRepository
    {

        private readonly DirectoryEntities _context;
        public AuthenticationRepository(DirectoryEntities context)
        {
            _context = context;
        }

        public Guid Login(string username, string passwordHash)
        {
            User user = _context.User.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

            if(user == null)
            {
                user = _context.User.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    user.AccessFailedCount++;

                    if (user.AccessFailedCount == 5)
                    {
                        user.Locked = true;
                        user.LockedComment = "Too many login attempts";
                        user.LockedDate = DateTime.Now;
                    }
                }

                throw new UnauthorizedAccessException("Invalid login information");
            }

            if (user.Locked)
            {
                throw new UnauthorizedAccessException("Invalid login user is locked", new Exception(user.LockedComment));
            }

            return user.UID;
        }

        public User GetUserInformation(Guid sessionUid)
        {
            var session = _context.Session.FirstOrDefault(s => s.UID == sessionUid);

            if(session == null)
            {
                throw new Exception("The session: " + sessionUid + " does not exists");
            }

            return session.User;
        }
    }
}
