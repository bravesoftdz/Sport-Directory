using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using Sport_Directory.DataContracts;
using Sport_Directory.DomainContracts.Authentication;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.Domain.Handler.Authentication
{
    public class LoginQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly LoginQuery _query;

        public LoginQueryHandler(LoginQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public Guid  Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            var sessionUid = uow.AuthenticationRepository.Login(_query.Username, _query.PasswordHash);

            uow.Commit();

            return sessionUid;
        }
    }
}
