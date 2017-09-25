using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Sport_Directory.Domain.Handler.Authentication;
using Sport_Directory.DomainContracts.Authentication;
using Sport_Directoy.DomainObjects;

namespace Sport_Directory.API.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost]
        public HttpResponseMessage Login([FromUri]UserDomainModel user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new NullReferenceException(nameof(user.Username));
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new NullReferenceException(nameof(user.PasswordHash));
            }

            LoginQuery query = new LoginQuery()
            {
                PasswordHash = user.PasswordHash,
                Username = user.Username
            };

            LoginQueryHandler handler = new LoginQueryHandler(query, UnityContainer);


            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }

        [HttpDelete]
        public HttpResponseMessage Logout(Guid sessionUid)
        {
            LogoutQuery query = new LogoutQuery()
            {
                SessionUID = sessionUid
            };

            LogoutQueryHandler handler = new LogoutQueryHandler(query, UnityContainer);
            handler.Handle();

            return Request.CreateResponse(HttpStatusCode.OK);;
        }

        [HttpGet]
        public HttpResponseMessage GetUser(Guid sessionUid)
        {
            GetUserQuery query = new GetUserQuery()
            {
                SessionUID = sessionUid
            };

            GetUserQueryHandler handler = new GetUserQueryHandler(query, UnityContainer);
            return Request.CreateResponse(HttpStatusCode.OK, handler.Handle());
        }
    }
}