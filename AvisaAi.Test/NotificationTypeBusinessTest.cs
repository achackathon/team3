using AvisaAi.Business;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvisaAi.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AvisaAi.Test
{
    [TestClass()]
    public class NotificationTypeBusinessTest
    {
        private NotificationTypeBusiness GetNotificationTypeBusiness()
        {
            return new NotificationTypeBusiness();
        }

        private List<NotificationType> GetNotificationObject()
        {
            return new List<NotificationType>() { NotObj() };
        }

        private NotificationType NotObj()
        {
            return new NotificationType()
            {
                Critical = false,
                Description = "teste description",
                Icon = "ion-usb",
                Name = "test name",
            };
        }

        #region [Get]

        [TestMethod]
        public void MustNotGet()
        {
            var result = GetNotificationTypeBusiness().Get();
            CollectionAssert.AreNotEqual(GetNotificationObject(), result.ToList());
        }

        #endregion

        #region [Get By User Id]

        [TestMethod]
        public void MustNotGetByUserId()
        {
            var result = GetNotificationTypeBusiness().GetByUserId(5);
            CollectionAssert.AreNotEqual(GetNotificationObject(), result.ToList());
        }

        #endregion

        #region [Get By Id]

        [TestMethod]
        public void MustNotGetById()
        {
            var result = GetNotificationTypeBusiness().GetById(5);
            Assert.AreNotEqual(NotObj(), result);
        }

        #endregion
    }
}
