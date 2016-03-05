app.factory('notifyService', function ($http, helperService) {
    var notifyObj = {
      notificationType: '',
      description: '',
      pis: '',
      email: ''
    };

    function storeNotify(obj) {
      //Code..
    };

    function retreveNotify() {
      return notify;
    };

    function notificationTypeOptions(notificationTypeId) {
      if(notificationTypeId == 1) {
        return [{ id:1, name:'Tipo de Notificação' }, { id:2, name:'Tipo de Notificação2' }];
      } else {
        return [{ id:1, name:'Tipo de Notificação3' }, { id:2, name:'Tipo de Notificação4' }];
      }
    }

    function notificationTypes() {
      return [{id:1,name:'Perigo'},{id:2,name:'Utilidade Publica'}];
    };

    function getMyNotifications(geo, callback) {
      helperService.getHttpRequest('Notification', callback);
      //return [{Id:2,Name:"First One!",Latitude:-43.935169,Longitude:-19.93622,Description:"Test notifiation",DateAdded:"2016-03-05T11:52:46",UserID:2,ExpiresOn:"2016-03-06T11:52:46",NotificationTypeId:1}];
    }

    return {
      get: function () {
        return retreveUser();
      },
      save: function(val) {
        storeNotify(val);
      },
      getOptions: function(notificationType){
        return notificationTypeOptions(notificationType);
      },
      getNotificationTypes: function() {
        return notificationTypes();
      },
      getNotification: function(geo, callback) {
        return getMyNotifications(geo,callback);
      }
    };
});
