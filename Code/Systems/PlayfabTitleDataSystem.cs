namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Playfab;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayfabTitleDataSystem : PlayfabTitleDataSystemBase {
        
        protected override void LoadComponentTitleData(ITitleData data, ITitleData group) {
        }
        
        protected override void LoadTitleDataHandler(Playfab.LoadData data) {
        }
    }
}
