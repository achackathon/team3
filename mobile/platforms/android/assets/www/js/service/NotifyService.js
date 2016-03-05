app.factory('notifyService', function () {
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

    function getMyNotifications(geo) {


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
      getNotification: function(geo) {
        return getMyNotifications(geo);
      }
    };
});
