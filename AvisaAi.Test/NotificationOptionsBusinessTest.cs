using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvisaAi.Data.Entities;
using System.Collections.Generic;
using AvisaAi.Business;

namespace AvisaAi.Test
{
    [TestClass()]
    public class NotificationOptionsBusinessTest
    {
        private NotificationOptionsBusiness GetNotificationOptionBusiness()
        {
            return new NotificationOptionsBusiness();
        }

        private NotificationOption GetNotificationOptionObject()
        {
            return new NotificationOption()
            {
                Description = "Test description",
                Name = "Name test",
                NotificationOptionID = 9,
                NotificationTypeId = 6
            };
        }

        #region [Get]

        [TestMethod]
        public void MustNotGet()
        {
            var result = GetNotificationOptionBusiness().GetByNotificationType(6);
            Assert.AreNotEqual(new List<NotificationOption>() { GetNotificationOptionObject() }, result);
        }

        #endregion
    }
}
