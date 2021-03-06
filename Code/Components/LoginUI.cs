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
    using UnityEngine.UI;
    using Invert.Json;
    using UniRx;
    using UnityEngine;
    using uFrame.ECS;
    
    
    [uFrame.Attributes.ComponentId(1)]
    [uFrame.Attributes.uFrameIdentifier("552ef875-918d-4b5d-a487-c52ff9c6663e")]
    public partial class LoginUI : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Toggle _RememberMe;
        
        [UnityEngine.SerializeField()]
        private InputField _Username;
        
        [UnityEngine.SerializeField()]
        private InputField _Password;
        
        private Subject<PropertyChangedEvent<Toggle>> _RememberMeObservable;
        
        private PropertyChangedEvent<Toggle> _RememberMeEvent;
        
        private Subject<PropertyChangedEvent<InputField>> _UsernameObservable;
        
        private PropertyChangedEvent<InputField> _UsernameEvent;
        
        private Subject<PropertyChangedEvent<InputField>> _PasswordObservable;
        
        private PropertyChangedEvent<InputField> _PasswordEvent;
        
        public override int ComponentId {
            get {
                return 1;
            }
        }
        
        public IObservable<PropertyChangedEvent<Toggle>> RememberMeObservable {
            get {
                return _RememberMeObservable ?? (_RememberMeObservable = new Subject<PropertyChangedEvent<Toggle>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<InputField>> UsernameObservable {
            get {
                return _UsernameObservable ?? (_UsernameObservable = new Subject<PropertyChangedEvent<InputField>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<InputField>> PasswordObservable {
            get {
                return _PasswordObservable ?? (_PasswordObservable = new Subject<PropertyChangedEvent<InputField>>());
            }
        }
        
        public Toggle RememberMe {
            get {
                return _RememberMe;
            }
            set {
                SetRememberMe(value);
            }
        }
        
        public InputField Username {
            get {
                return _Username;
            }
            set {
                SetUsername(value);
            }
        }
        
        public InputField Password {
            get {
                return _Password;
            }
            set {
                SetPassword(value);
            }
        }
        
        public virtual void SetRememberMe(Toggle value) {
            SetProperty(ref _RememberMe, value, ref _RememberMeEvent, _RememberMeObservable);
        }
        
        public virtual void SetUsername(InputField value) {
            SetProperty(ref _Username, value, ref _UsernameEvent, _UsernameObservable);
        }
        
        public virtual void SetPassword(InputField value) {
            SetProperty(ref _Password, value, ref _PasswordEvent, _PasswordObservable);
        }
    }
}
