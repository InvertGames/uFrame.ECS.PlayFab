using Invert.Json;
using PlayFab;
using PlayFab.ClientModels;

namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using Playfab;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerDataSystem : PlayFabPlayerDataSystemBase {

        /// <summary>
        /// Load Cloud Data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="group"></param>
        protected override void LoadCloudDataComponent(ICloudData data, ICloudData group)
        {
            if (PlayerData == null) return;
            // The key that we store the json data in.
            var key = group.EntityId + "_" + group.ComponentId;
            // If the data doesn't exist no need to go any further
            if (!PlayerData.ContainsKey(key)) return;

            var jsonNode = JSONNode.Parse(PlayerData[key]);

            group.DeserializeComponent<CloudDataAttribute>(jsonNode);

        }

        /// <summary>
        /// THis method is invoked for every component that is a ICloudData component.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="group"></param>
        protected override void LoadCloudDataHandler(Playfab.LoadData data)
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), _ =>
            {
                // Store the players data locally
                PlayerData = _.Data.ToDictionary(p => p.Key, p => p.Value.Value);
                foreach (var item in CloudDataManager.Components)
                {
                    // Pass it to the LoadCloudDataComponent
                    LoadCloudDataComponent(item, item);
                }
            }, _ => { });
           
        }

   
        /// <summary>
        /// Signal the update call to Playfab to persist the data.
        /// </summary>
        /// <param name="data"></param>
        protected override void SaveCloudDataHandler(SaveData data)
        {
            base.SaveCloudDataHandler(data);

            // If the data doesn't exist no need to go any further
            //if (!PlayerData.ContainsKey(key)) return;

            // Serialize all the cloud data components
            foreach (var item in CloudDataManager.Components)
            {
                var key = item.EntityId + "_" + item.ComponentId;
                if (!PlayerData.ContainsKey(key)) PlayerData.Add(key, string.Empty);
                PlayerData[key] = item.SerializeComponent<CloudDataAttribute>().ToString();
            }
            // Save the data to the cloud.
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = PlayerData,
            }, _ =>
            {

            }, _ => { });
        }
    }
}
