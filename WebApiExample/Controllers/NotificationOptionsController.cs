using AvisaAi.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AvisaAi.WebApi.Controllers
{
    public class NotificationOptionsController : ApiController
    {
        [HttpPost]
        [Route("notificationoptions/getbynotificationtype")]
        public HttpResponseMessage Get()
        {
            try
            {
                var notifications = new NotificationOptionsBusiness().GetByNotificationType(1);
                return Request.CreateResponse(HttpStatusCode.OK, notifications);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
