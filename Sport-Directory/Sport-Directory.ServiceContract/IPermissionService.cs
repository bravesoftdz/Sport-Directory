using System;

namespace Sport_Directory.ServiceContract
{
    public interface IPermissionService
    {
        bool IsPremitted(Guid sessionUid, string execution);
    }
}
