namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using Playfab;
    using UnityEngine.UI;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class NotificationsUISystem : NotificationsUISystemBase {
        protected override void DisplayNotificationMessageHandler(NotificationMessage data, NotificationUI @group)
        {
            base.DisplayNotificationMessageHandler(data, @group);
            group.MessageText.text = data.Message;
            group.TitleText.text = data.Title;
            group.gameObject.SetActive(true);
            Observable.Timer(new TimeSpan(0, 0, 5)).Subscribe(_ =>
            {
                group.gameObject.SetActive(false);
            }).DisposeWith(this).DisposeWith(group);
        }

        protected override void DisableAllNotificationUIHandler(GameReadyEvent data, NotificationUI @group)
        {
            base.DisableAllNotificationUIHandler(data, @group);
            group.gameObject.SetActive(false);
        }
    }
}
