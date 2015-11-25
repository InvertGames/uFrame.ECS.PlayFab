namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Playfab;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerStatsSystem : PlayFabPlayerStatsSystemBase {
        
        protected override void SavePlayerStatsHandler(Playfab.SaveData data) {
        }
        
        protected override void LoadPlayerStatsHandler(Playfab.LoadData data) {
        }
        
        protected override void LoadPlayerStat(IPlayerStat data, IPlayerStat group) {
        }
    }
}
