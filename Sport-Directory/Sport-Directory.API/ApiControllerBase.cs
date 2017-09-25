using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Practices.Unity;

namespace Sport_Directory.API
{
    public class ApiControllerBase : ApiController
    {

        public static IUnityContainer UnityContainer { get; set; }
    }
}