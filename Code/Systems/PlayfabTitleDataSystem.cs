using System.Reflection;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayfabTitleDataSystem : PlayfabTitleDataSystemBase {
        public override void Setup()
        {
            base.Setup();
        }

        public void LoadBlackBoardData(IBlackBoardComponent blackboardComponent)
        {
            foreach (var property in blackboardComponent.GetType().GetProperties())
            {
                if (TitleData.ContainsKey(property.Name))
                {
                    
                }
            }
        }

        public BlackBoardGroup BlackBoardGroup { get; set; }

        protected override void LoadTitleDataHandler(LoadData data)
        {
            base.LoadTitleDataHandler(data);

            var complete = false;
            PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), _ =>
            {
                TitleData = _.Data;

                foreach (var item in uFrameKernel.Instance.Services)
                {
                    foreach (var x in TitleData.Keys)
                    {
                        var property = item.GetType().GetProperty(x, BindingFlags.Default);
                        if (property != null && property.PropertyType == typeof(string))
                        {
                            property.SetValue(item, TitleData[x], null);
                        }
                    }
                }
            }, _ =>
            {
               
            });
         
          
        }

        public override void Loaded()
        {
            base.Loaded();
        
        }

        public Dictionary<string, string> TitleData { get; set; }
    }
}
