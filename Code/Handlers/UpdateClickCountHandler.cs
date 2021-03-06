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
    
    
    public class UpdateClickCount {
        
        public ClickCount Group;
        
        public int OldValue;
        
        public int NewValue;
        
        private ClickCount _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private string FormatStringAction9_Result = default( System.String );
        
        public ClickCount Event {
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
            // FormatStringAction
            FormatStringAction9_Result = string.Format(@"ClickCount: {0}", Group.Count);
            // SetVariableNode
            DemoPlayerSystem.Instance.ClickCountLabel.text = (System.String)FormatStringAction9_Result;
        }
    }
}
