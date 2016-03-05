using AvisaAi.Business;
using System;
using System.Net;
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

            var notifications = new NotificationTypeBusiness().Get();
            return Request.CreateResponse(HttpStatusCode.OK, notifications);

        }

        [HttpGet]
        [Route("notificationType/{id}")]
        public HttpResponseMessage GetById(int id)
        {

            var notification = new NotificationTypeBusiness().GetById(id);

            if (notification == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, notification);
        }

        [HttpGet]
        [Route("notificationType/user/{id}")]
        public HttpResponseMessage GetByUser(int id)
        {

            var notification = new NotificationTypeBusiness().GetByUserId(id);

            if (notification == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, notification);
        }

        #endregion
    }
}
