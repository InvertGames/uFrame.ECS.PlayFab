using PlayFab;
using PlayFab.ClientModels;

namespace Playfab {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayFabPlayerStatsSystem : PlayFabPlayerStatsSystemBase {
        /// <summary>
        /// Requests playfab to load all of the data from playfab
        /// </summary>
        /// <param name="data"></param>
        protected override void LoadPlayerStatsHandler(LoadData data)
        {
            base.LoadPlayerStatsHandler(data);
            PlayFabClientAPI.GetUserStatistics(new GetUserStatisticsRequest(), result =>
            {
                PlayerStats = result.UserStatistics;
                foreach (var item in this.PlayerStatManager.Components)
                {
                    LoadPlayerStat(item,item);
                }
            },
                _ =>
                {
                    this.Publish(new NotificationMessage()
                    {
                        Message = _.ErrorMessage
                    });
                });
        }

        protected override void LoadPlayerStat(IPlayerStat data, IPlayerStat @group)
        {
            base.LoadPlayerStat(data, @group);
            if (PlayerStats == null) return;

            foreach (var item in @group.PlayerStatMembers)
            {
                var key = string.Format("{0}_{1}_{2}", @group.EntityId, @group.ComponentId, item.Name);
                if (PlayerStats.ContainsKey(key))
                {
                    item.SetValue(group, PlayerStats[key], null);
                }
            }
        }

        protected override void SavePlayerStatsHandler(SaveData data)
        {
            base.SavePlayerStatsHandler(data);
            foreach (var component in PlayerStatManager.Components)
            {
                foreach (var item in component.PlayerStatMembers)
                {
                    var key = string.Format("{0}_{1}_{2}", component.EntityId, component.ComponentId, item.Name);

                    if (!PlayerStats.ContainsKey(key))
                    {
                        PlayerStats.Add(key,0);
                    }
                    PlayerStats[key] = (int)item.GetValue(component, null);
                }
            }
            PlayFabClientAPI.UpdateUserStatistics(new UpdateUserStatisticsRequest() {UserStatistics = PlayerStats},
                _ =>
                {
                    
                },_=>{});

        }
    }
}
