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
    using Playfab;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayfabTitleDataSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<ITitleData> _TitleDataManager;
        
        public IEcsComponentManagerOf<ITitleData> TitleDataManager {
            get {
                return _TitleDataManager;
            }
            set {
                _TitleDataManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            TitleDataManager = ComponentSystem.RegisterGroup<TitleDataGroup,ITitleData>();
            TitleDataManager.CreatedObservable.Subscribe(LoadComponentTitleDataFilter).DisposeWith(this);
            this.OnEvent<Playfab.LoadData>().Subscribe(_=>{ LoadTitleDataFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void LoadComponentTitleData(ITitleData data, ITitleData group) {
        }
        
        protected void LoadComponentTitleDataFilter(ITitleData data) {
            var GroupItem = TitleDataManager[data.EntityId];
            if (GroupItem == null) {
                return;
            }
            if (!GroupItem.Enabled) {
                return;
            }
            this.LoadComponentTitleData(data, GroupItem);
        }
        
        protected virtual void LoadTitleDataHandler(Playfab.LoadData data) {
        }
        
        protected void LoadTitleDataFilter(Playfab.LoadData data) {
            this.LoadTitleDataHandler(data);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("3cd0ed7a-2dc7-4aaf-b16b-b3e77e48a790")]
    public partial class PlayfabTitleDataSystem : PlayfabTitleDataSystemBase {
        
        private static PlayfabTitleDataSystem _Instance;
        
        public PlayfabTitleDataSystem() {
            Instance = this;
        }
        
        public static PlayfabTitleDataSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
