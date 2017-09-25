using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Sport_Directory.Data;
using Sport_Directory.DataContracts;
using Sport_Directory.DomainContracts.Authentication;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.Domain.Handler.Authentication
{
    public class GetUserQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly GetUserQuery _query;

        public GetUserQueryHandler(GetUserQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public  UserDomainModel Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            return Mapper.Map<UserDomainModel>(uow.AuthenticationRepository.GetUserInformation(_query.SessionUID));
        }
    }
}
