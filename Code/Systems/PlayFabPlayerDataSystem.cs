namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Playfab;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerDataSystem : PlayFabPlayerDataSystemBase {
        
        protected override void LoadCloudDataHandler(Playfab.LoadData data) {
        }
        
        protected override void SaveCloudDataHandler(Playfab.SaveData data) {
        }
        
        protected override void LoadCloudDataComponent(ICloudData data, ICloudData group) {
        }
    }
}
