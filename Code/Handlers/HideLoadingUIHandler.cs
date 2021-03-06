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
    using UnityEngine;
    using uFrame.ECS;
    
    
    public class HideLoadingUIHandler {
        
        private Playfab.UserLoggedIn _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private Playfab.LoginLoadingUI LoopGroupNode18_Item = default( Playfab.LoginLoadingUI );
        
        private UnityEngine.GameObject ActionNode19_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.MonoBehaviour ActionNode19_behaviour = default( UnityEngine.MonoBehaviour );
        
        private Playfab.VisibleWhenAuthenticated LoopGroupNode23_Item = default( Playfab.VisibleWhenAuthenticated );
        
        private UnityEngine.GameObject ActionNode25_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.MonoBehaviour ActionNode25_behaviour = default( UnityEngine.MonoBehaviour );
        
        private Playfab.VisibleWhenNotAuthenticated LoopGroupNode26_Item = default( Playfab.VisibleWhenNotAuthenticated );
        
        private UnityEngine.GameObject ActionNode27_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.MonoBehaviour ActionNode27_behaviour = default( UnityEngine.MonoBehaviour );
        
        public Playfab.UserLoggedIn Event {
            get {
                return _Event;
            }
            set {
                _Event = value;
            }
        }
        
        public uFrame.ECS.EcsSystem System {
            get {
                return _System;
            }
            set {
                _System = value;
            }
        }
        
        public virtual void Execute() {
            // LoopGroupNode
            var LoopGroupNode18_GroupComponents = System.ComponentSystem.RegisterComponent<Playfab.LoginLoadingUI>().Components;
            for (var LoopGroupNode18_ItemIndex = 0
            ; LoopGroupNode18_ItemIndex < LoopGroupNode18_GroupComponents.Count; LoopGroupNode18_ItemIndex++
            ) {
                LoopGroupNode18_Item = LoopGroupNode18_GroupComponents[LoopGroupNode18_ItemIndex];
                LoopGroupNode18_Next();
            }
            // LoopGroupNode
            var LoopGroupNode23_GroupComponents = System.ComponentSystem.RegisterComponent<Playfab.VisibleWhenAuthenticated>().Components;
            for (var LoopGroupNode23_ItemIndex = 0
            ; LoopGroupNode23_ItemIndex < LoopGroupNode23_GroupComponents.Count; LoopGroupNode23_ItemIndex++
            ) {
                LoopGroupNode23_Item = LoopGroupNode23_GroupComponents[LoopGroupNode23_ItemIndex];
                LoopGroupNode23_Next();
            }
            // LoopGroupNode
            var LoopGroupNode26_GroupComponents = System.ComponentSystem.RegisterComponent<Playfab.VisibleWhenNotAuthenticated>().Components;
            for (var LoopGroupNode26_ItemIndex = 0
            ; LoopGroupNode26_ItemIndex < LoopGroupNode26_GroupComponents.Count; LoopGroupNode26_ItemIndex++
            ) {
                LoopGroupNode26_Item = LoopGroupNode26_GroupComponents[LoopGroupNode26_ItemIndex];
                LoopGroupNode26_Next();
            }
        }
        
        private void LoopGroupNode18_Next() {
            ActionNode19_behaviour = LoopGroupNode18_Item;
            // ActionNode
            // Visit uFrame.Actions.GameObjects.DeactiateGameObject
            uFrame.Actions.GameObjects.DeactiateGameObject(ActionNode19_gameObject, ActionNode19_behaviour);
        }
        
        private void LoopGroupNode23_Next() {
            ActionNode25_behaviour = LoopGroupNode23_Item;
            // ActionNode
            // Visit uFrame.Actions.GameObjects.ActivateGameObject
            uFrame.Actions.GameObjects.ActivateGameObject(ActionNode25_gameObject, ActionNode25_behaviour);
        }
        
        private void LoopGroupNode26_Next() {
            ActionNode27_behaviour = LoopGroupNode26_Item;
            // ActionNode
            // Visit uFrame.Actions.GameObjects.DeactiateGameObject
            uFrame.Actions.GameObjects.DeactiateGameObject(ActionNode27_gameObject, ActionNode27_behaviour);
        }
    }
}
