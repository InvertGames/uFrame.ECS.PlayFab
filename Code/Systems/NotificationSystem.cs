namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class NotificationSystem : NotificationSystemBase {
        protected override void LogDebugMessageHandler(NotificationMessage data)
        {
            base.LogDebugMessageHandler(data);
            if (DebugLog)
            UnityEngine.Debug.Log(data.Title + ": " + data.Message);
        }
    }
}
