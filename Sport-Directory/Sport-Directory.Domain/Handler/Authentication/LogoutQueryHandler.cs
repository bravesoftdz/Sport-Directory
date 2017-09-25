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
    public class LogoutQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly LogoutQuery _query;

        public LogoutQueryHandler(LogoutQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public void Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            uow.SessionRepository.RemoveSession(_query.SessionUID);

            uow.Commit();
        }
    }
}
