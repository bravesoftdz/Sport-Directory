using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sport_Directory.Data;

namespace Sport_Directory.DataContracts
{
    public class DirectoryUnitOfWork
    {
        private DirectoryEntities _context;

        public DirectoryUnitOfWork(DirectoryEntities context = null)
        {
            _context = context ?? new DirectoryEntities();
            AuthenticationRepository = new AuthenticationRepository(_context);
            MandatorRepository = new MandatorRepository(_context);
            SessionRepository = new SessionRepository(_context);
        }
        public AuthenticationRepository AuthenticationRepository { get; set; }

        public MandatorRepository MandatorRepository { get; set; }

        public SessionRepository SessionRepository { get; set; }

        public void Commit()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);
        }
    }
}
