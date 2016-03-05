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
            try
            {
                var notifications = new NotificationTypeBusiness().Get();
                return Request.CreateResponse(HttpStatusCode.OK, notifications);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("notificationType/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var notification = new NotificationTypeBusiness().GetById(id);

                if (notification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, notification);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("notificationType/user/{id}")]
        public HttpResponseMessage GetByUser(int id)
        {
            try
            {
                var notification = new NotificationTypeBusiness().GetByUserId(id);

                if (notification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, notification);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
