using System;
using Sport_Directory.Data;

namespace Sport_Directory.ServiceContract
{
    public interface IAuthenticationService
    {
        Guid Login(string username, string password);

        void Logout(Guid sessionUid);

        User GetUser(Guid sessionUid);
    }
}
