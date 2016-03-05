app.factory('notifyService', function ($http, helperService) {
    function storeNotify(obj) {
      //Code..
    };

    function retreveNotify() {
      return notify;
    };

    function notificationTypeOptions(notificationTypeId, callback) {
      helperService.getHttpRequest('notificationoptions/getbynotificationtype', notificationTypeId,  callback);
    }

    function notificationTypes(callback) {
      helperService.getHttpRequest('v1/NotificationType', null, callback);
    };

    function getMyNotifications(geo, callback) {
      helperService.getHttpRequest('Notification', null, callback);
    };

    return {
      get: function () {
        return retreveUser();
      },
      save: function(val) {
        storeNotify(val);
      },
      getOptions: function(notificationType, callback){
        return notificationTypeOptions(notificationType, callback);
      },
      getNotificationTypes: function(callback) {
        return notificationTypes(callback);
      },
      getNotification: function(geo, callback) {
        return getMyNotifications(geo,callback);
      }
    };
});
