// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    using Playfab;
    
    
    public partial class PlayFabPlayerDataSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<ICloudData> _CloudDataManager;
        
        public IEcsComponentManagerOf<ICloudData> CloudDataManager {
            get {
                return _CloudDataManager;
            }
            set {
                _CloudDataManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            CloudDataManager = ComponentSystem.RegisterGroup<CloudDataGroup,ICloudData>();
            this.OnEvent<Playfab.LoadData>().Subscribe(_=>{ LoadCloudDataFilter(_); }).DisposeWith(this);
            this.OnEvent<Playfab.SaveData>().Subscribe(_=>{ SaveCloudDataFilter(_); }).DisposeWith(this);
            CloudDataManager.CreatedObservable.Subscribe(LoadCloudDataComponentFilter).DisposeWith(this);
        }
        
        protected virtual void LoadCloudDataHandler(Playfab.LoadData data) {
        }
        
        protected void LoadCloudDataFilter(Playfab.LoadData data) {
            this.LoadCloudDataHandler(data);
        }
        
        protected virtual void SaveCloudDataHandler(Playfab.SaveData data) {
        }
        
        protected void SaveCloudDataFilter(Playfab.SaveData data) {
            this.SaveCloudDataHandler(data);
        }
        
        protected virtual void LoadCloudDataComponent(ICloudData data, ICloudData group) {
        }
        
        protected void LoadCloudDataComponentFilter(ICloudData data) {
            var GroupItem = CloudDataManager[data.EntityId];
            if (GroupItem == null) {
                return;
            }
            if (!GroupItem.Enabled) {
                return;
            }
            this.LoadCloudDataComponent(data, GroupItem);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("47dacb94-3ce5-49d0-933f-1b2919ed93ce")]
    public partial class PlayFabPlayerDataSystem : PlayFabPlayerDataSystemBase {
        
        private static PlayFabPlayerDataSystem _Instance;
        
        [UnityEngine.SerializeField()]
        private Dictionary<string,string> _PlayerData;
        
        public PlayFabPlayerDataSystem() {
            Instance = this;
        }
        
        public static PlayFabPlayerDataSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
        
        public Dictionary<string,string> PlayerData {
            get {
                return _PlayerData;
            }
            set {
                _PlayerData = value;
            }
        }
    }
}
