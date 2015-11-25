namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayfabLoginSystem : PlayfabLoginSystemBase {
        
        protected override void LoginAsGuestHandler(uFrame.Kernel.GameReadyEvent data) {
        }
        
        protected override void PlayfabLoginSystemLoginUserHandler(Playfab.LoginUser data) {
        }
    }
}
