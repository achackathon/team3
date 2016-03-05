using System.Net.Http;
using System.Web.Http;

namespace AvisaAi.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class NotificationTypeController : ApiController
    {
        #region [Get]

        [HttpGet]
        [Route("notificationType")]
        public HttpResponseMessage Get()
        {
            //teste
            return null;
        }

        #endregion
    }
}
