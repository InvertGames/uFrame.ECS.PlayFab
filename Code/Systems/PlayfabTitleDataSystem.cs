using System.Reflection;
using BehaviorDesigner.Runtime;
using Invert.Json;
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
        }

        protected override void LoadComponentTitleData(ITitleData data, ITitleData @group)
        {
            base.LoadComponentTitleData(data, @group);

            foreach (var property in data.GetType().GetProperties())
            {
                if (TitleData.ContainsKey(property.Name))
                {
                    EcsComponentExtensions.ApplyValue(data, new JSONNode() { Value = TitleData[property.Name] }, property);
                }
            }
        }

        public BlackBoardGroup BlackBoardGroup { get; set; }

        protected override void LoadTitleDataHandler(LoadData data)
        {
            base.LoadTitleDataHandler(data);
            PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), _ =>
            {
                TitleData = _.Data;

                foreach (var item in TitleDataManager.Components)
                {
                    LoadComponentTitleData(item,item);
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
