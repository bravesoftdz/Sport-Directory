using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sport_Directory.Domain.Handler.Mandator;
using Sport_Directory.DomainContracts.Mandator;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.API.Controllers
{
    public class MandatorController : ApiControllerBase
    {
        [HttpGet]
        public HttpResponseMessage GetMandatorUid(Guid sessionid)
        {
            GetMandatorUidQuery query = new GetMandatorUidQuery()
            {
                SessionUID = sessionid
            };

            GetMandatorUidQueryHandler handler = new GetMandatorUidQueryHandler(query, UnityContainer);

            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }

        [HttpGet]
        public HttpResponseMessage GetMandatorSettings(Guid mandatorUid, string key)
        {
            GetMandatorSettingQuery query = new GetMandatorSettingQuery()
            {
                MandatorUID = mandatorUid,
                Key = key
            };

            GetMandatorSettingQueryHandler handler = new GetMandatorSettingQueryHandler(query, UnityContainer);

            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }

        [HttpGet]
        public HttpResponseMessage GetMandatorSetting(Guid mandatorUid, string key)
        {
            GetMandatorSettingsQuery query = new GetMandatorSettingsQuery()
            {
                MandatorUID = mandatorUid
            };

            GetMandatorSettingsQueryHandler handler = new GetMandatorSettingsQueryHandler(query, UnityContainer);
            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }
    }
}