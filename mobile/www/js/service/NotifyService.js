app.factory('notifyService', function ($http, helperService) {
    function storeNotify(param, callback) {
      helperService.postHttp('Notification', param, callback)
    };

    function retreveNotify() {
      return notify;
    };

    function notificationTypeOptions(notificationTypeId, callback) {
      helperService.getHttpRequest('NotificationOptions/?notificationTypeId=' + notificationTypeId, null,  callback);
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
      save: function(myNotification, callback) {
        storeNotify(myNotification, callback);
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
