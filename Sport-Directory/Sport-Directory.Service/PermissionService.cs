using System;
using Sport_Directory.ServiceContract;

namespace Sport_Directory.Service
{
    public class PermissionService : IPermissionService
    {
        public bool IsPremitted(Guid sessionUid, string execution)
        {
            if (string.IsNullOrEmpty(execution))
            {
                throw new ArgumentNullException(nameof(execution));
            }

            return true;
        }
    }
}
