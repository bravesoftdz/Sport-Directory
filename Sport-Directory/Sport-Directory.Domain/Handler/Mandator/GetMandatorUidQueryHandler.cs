using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Sport_Directory.DataContracts;
using Sport_Directory.DomainContracts.Mandator;

namespace Sport_Directory.Domain.Handler.Mandator
{
    public class GetMandatorUidQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly GetMandatorUidQuery _query;

        public GetMandatorUidQueryHandler(GetMandatorUidQuery query, IUnityContainer unityContainer)
            : base(unityContainer)
        {
            _query = query;
        }

        public Guid Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            return uow.MandatorRepository.GetMandatorUid(_query.SessionUID);
        }
    }
}
