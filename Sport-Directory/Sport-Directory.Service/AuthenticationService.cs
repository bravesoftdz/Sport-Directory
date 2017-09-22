using System;
using Sport_Directory.Data;
using Sport_Directory.ServiceContract;

namespace Sport_Directory.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationRepository _authenticationRepository;
        private readonly SessionRepository _sessionRepository;
        
        public AuthenticationService(AuthenticationRepository authenticationRepository , SessionRepository sessionRepository)
        {
            if (authenticationRepository != null)
            {
                _authenticationRepository = authenticationRepository;
            }
            else
            {
                _authenticationRepository = new AuthenticationRepository(new DirectoryEntities());
            }

            if (sessionRepository != null)
            {
                _sessionRepository = sessionRepository;
            }
            else
            {
                _sessionRepository = new SessionRepository(new DirectoryEntities());
            }
        }

        public Guid Login(string username, string passwordHash)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new NullReferenceException(nameof(username));
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new NullReferenceException(nameof(passwordHash));
            }

            Guid userUid = _authenticationRepository.Login(username, passwordHash);

            Guid sessionUid = _sessionRepository.RegisterSession(userUid);

            return sessionUid;
        }

        public void Logout(Guid sessionUid)
        {
            _sessionRepository.RemoveSession(sessionUid);
        }

        public User GetUser(Guid sessionUid)
        {
            return _authenticationRepository.GetUserInformation(sessionUid);
        }
    }
}
