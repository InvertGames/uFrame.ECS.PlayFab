namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Playfab;
    using UnityEngine.UI;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class NotificationsUISystem : NotificationsUISystemBase {
        
        protected override void DisableAllNotificationUIHandler(uFrame.Kernel.GameReadyEvent data, NotificationUI group) {
        }
        
        protected override void DisplayNotificationMessageHandler(Playfab.NotificationMessage data, NotificationUI group) {
        }
    }
}
