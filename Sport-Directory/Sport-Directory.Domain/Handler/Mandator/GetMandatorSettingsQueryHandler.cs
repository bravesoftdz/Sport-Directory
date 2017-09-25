using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.Unity;
using Sport_Directory.DataContracts;
using Sport_Directory.DomainContracts.Mandator;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.Domain.Handler.Mandator
{
    public class GetMandatorSettingsQueryHandler : QueryHandlerBase.QueryHandlerBase
    {
        private readonly GetMandatorSettingsQuery _query;

        public GetMandatorSettingsQueryHandler(GetMandatorSettingsQuery query, IUnityContainer unityContainer) : base(unityContainer)
        {
            _query = query;
        }

        public List<MandatorSettingDomainModel> Handle()
        {
            DirectoryUnitOfWork uow = new DirectoryUnitOfWork();

            return Mapper.Map<List<MandatorSettingDomainModel>>(uow.MandatorRepository.GetMandatorSetting(_query.MandatorUID));
        }
    }
}
