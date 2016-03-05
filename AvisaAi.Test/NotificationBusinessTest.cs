using AvisaAi.Business;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvisaAi.Data.Entities;
using System.Collections.Generic;

namespace AvisaAi.Test
{
    [TestClass()]
    public class NotificationBusinessTest
    {
        private NotificationBusiness GetNotificationBusiness()
        {
            return new NotificationBusiness(new DB.NotificationDB());
        }

        private Notification GetNotificationObject()
        {
            return new Notification()
            {
                DateAdded = DateTime.Now,
                Description = "Test Description",
                ExpiresOn = DateTime.Now.AddDays(1),
                Latitude = -19.909073,
                Longitude = -43.977390,
                Name = "Test name",
                NotificationTypeId = 6,
                UserID = 5
            };
        }

        #region [Add]

        [TestMethod]
        public void MustAdd()
        {
            var result = GetNotificationBusiness().Add(GetNotificationObject());
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MustNotAdd()
        {
            var obj = GetNotificationObject();
            obj.Name = null;

            var result = GetNotificationBusiness().Add(obj);
        }

        #endregion

        #region [Get]

        [TestMethod]
        public void MustNotGet()
        {
            var result = GetNotificationBusiness().Get();
            CollectionAssert.AreNotEqual(new List<Notification>() { GetNotificationObject() }, result);
        }

        #endregion

        #region [Get Nearby]

        [TestMethod]
        public void MustNotGetNearby()
        {
            var result = GetNotificationBusiness().Get(-19.909073, -43.977390);
            CollectionAssert.AreNotEqual(new List<Notification>() { GetNotificationObject() }, result);
        }

        #endregion
    }
}
