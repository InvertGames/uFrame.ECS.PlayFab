using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PlayFab;
using PlayFab.ClientModels;
using uFrame.Attributes;
using uFrame.ECS;
using UnityEngine;
using UniRx;
public class PlayFabService : PlayerDataService
{

    public string Title_Id;
    public override void Setup()
    {
        base.Setup();
        this.OnEvent<LoginPlayfabUser>().Subscribe(_ =>
        {
            PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
            {
                TitleId = Title_Id,
                Username = _.Username,
                Password = _.Password
            },result =>
            {
                GetUserDataRequest request = new GetUserDataRequest()
                {

                };
                PlayFabClientAPI.GetUserData(request, userDataResult =>
                {
                    Data = userDataResult.Data;
                }, null, null);

            },null);
        });
    }
    public Dictionary<string, UserDataRecord> Data { get; set; }
    public override IEnumerator SetupAsync()
    {

        return base.SetupAsync();

    }

    public override void Load(LoadPlayerData data)
    {
        base.Load(data);

    }

    
    public override void Loaded()
    {
        base.Loaded();

    }



}
[uFrameEvent("Login Playfab User")]
public class LoginPlayfabUser
{
    public string Username { get; set; }
    public string Password { get; set; }
}


public class PlayFabRepository : JsonComponentRepository
{
    public override void Initialize(PlayerDataGroup @group)
    {
      
    }
    
    public override void LoadComponent(IPlayerDataComponent ecsComponent)
    {
        
    }

    public override void SaveComponent(IPlayerDataComponent ecsComponent)
    {
        throw new System.NotImplementedException();
    }
}

public class uFramePlayfab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
