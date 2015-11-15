namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using uFrame.ECS;
    using uFrame.Kernel;
    
    
    public partial class DemoPlayerSystem : DemoPlayerSystemBase {
        protected override void NotifyLoginHandler(UserLoggedIn data)
        {
            base.NotifyLoginHandler(data);
            Publish(new NotificationMessage()
            {
                Title = "Logged In",
                Message = "Welcome to my game!"
            });
        }

        
    }
}
