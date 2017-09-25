using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using Sport_Directory.DataContracts;
using Sport_Directory.DomainContracts.Authentication;
using Sport_Directory.DomainContracts.Mandator;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.Domain.Handler.Mandator
{
    public class GetMandatorSettingQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly GetMandatorSettingQuery _query;

        public GetMandatorSettingQueryHandler(GetMandatorSettingQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public MandatorSettingDomainModel Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            return Mapper.Map<MandatorSettingDomainModel>(uow.MandatorRepository.GetMandatorSetting(_query.MandatorUID, _query.Key).First());
        }
    }
}
