using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Playfab
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;



    public partial class PlayfabLoginSystem : PlayfabLoginSystemBase
    {
        public override void Setup()
        {
            PlayFabSettings.TitleId = TitleId;
            base.Setup();
        }


        protected override void LoginAsGuestHandler(GameReadyEvent data)
        {
            base.LoginAsGuestHandler(data);
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
            {
                CreateAccount = true,
                CustomId = SystemInfo.deviceUniqueIdentifier
            }, result =>
            {
                this.Publish(new UserLoggedIn());
           
            }, error =>
            {
          
            });
        }

        protected override void PlayfabLoginSystemLoginUserHandler(LoginUser data)
        {
            base.PlayfabLoginSystemLoginUserHandler(data);
            PlayFabClientAPI.LoginWithEmailAddress(new PlayFab.ClientModels.LoginWithEmailAddressRequest()
            {
                Email = data.Email,
                Password = data.Password
            }, result =>
            {

                this.Publish(new UserLoggedIn());
            }, error =>
            {
                this.Publish(new LoginUserError()
                {
                    ErrorMessage = error.ErrorMessage
                });
            });
        }
    }
}
